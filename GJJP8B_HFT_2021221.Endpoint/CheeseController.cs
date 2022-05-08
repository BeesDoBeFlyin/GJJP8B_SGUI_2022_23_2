using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private ICheeseLogic cheeseLogic;
        private readonly IHubContext<SignalRHub> hub;

        public CheeseController(ICheeseLogic cheeseLogic, IHubContext<SignalRHub> hub)
        {
            this.cheeseLogic = cheeseLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cheese> ReadAll()
        {
            return cheeseLogic.GetAll();
        }

        [Route("Read/{id}")]
        [HttpGet]
        public Cheese Read(int id)
        {
            return cheeseLogic.GetCheeseById(id);
        }

        [Route("Create/{newCheese}")]
        [HttpPost]
        public void Create(Cheese newCheese)
        {
            cheeseLogic.AddCheese(newCheese);
            hub.Clients.All.SendAsync("CheeseCreated", newCheese);
        }

        [Route("ChangeCheeseName/{id}/{newName}")]
        [HttpPut]
        public void ChangeCheeseName(int id, string newName)
        {
            cheeseLogic.ChangeCheeseName(id, newName);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Cheese cheeseToDelete = cheeseLogic.GetCheeseById(id);
            cheeseLogic.DeleteCheeseById(id);
            hub.Clients.All.SendAsync("CheeseDeleted", cheeseToDelete);
        }

        [Route("ChangePrice/{id}/{price}")]
        [HttpPut]
        public void ChangePrice(int id, float price)
        {
            cheeseLogic.ChangePrice(id, price);
        }

        [Route("EditAll/{id}/{name}-{price}-{milkId}")]
        [HttpPut("editAll")]
        public void EditCheese(Cheese cheese)
        {
            cheeseLogic.ChangeCheeseName(cheese.Id, cheese.Name);
            cheeseLogic.ChangePrice(cheese.Id, cheese.Price);
            cheeseLogic.ChangeMilk(cheese.Id, cheese.MilkId);
        }

        [Route("UnderPrice/{price}")]
        [HttpGet]
        public IEnumerable<Cheese> GetCheesesUnderPrce(float price)
        {
            return cheeseLogic.CheesesUnderPrice(price);
        }

        [Route("AtPrice/{price}")]
        [HttpGet]
        public IEnumerable<Cheese> GetCheesesAtPrice(float price)
        {
            return cheeseLogic.CheesesAtPrice(price);
        }

        [Route("AbovePrice/{price}")]
        [HttpGet]
        public IEnumerable<Cheese> GetCheesesAbovePrce(float price)
        {
            return cheeseLogic.CheesesAbovePrice(price);
        }

        [Route("MadeOf/{id}")]
        [HttpGet]
        public IEnumerable MadeOf(int id)
        {
            return cheeseLogic.MadeOf(id);
        }

        [Route("ListCheesesMadeOfGivenMilk/{id}")]
        [HttpGet]
        public IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(int id)
        {
            return cheeseLogic.ListCheesesMadeOfGivenMilk(id);
        }

        [Route("ListCheesesWithMaterialCheaperThanGiven/{price}")]
        [HttpGet]
        public IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price)
        {
            return cheeseLogic.ListCheesesWithMaterialCheaperThanGiven(price);
        }
    }
}
