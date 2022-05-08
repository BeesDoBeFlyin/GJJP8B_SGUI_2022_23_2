using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        ICheeseLogic cheeseLogic;
        IHubContext<SignalRHub> hub;

        public CheeseController(ICheeseLogic logic, IHubContext<SignalRHub> hub)
        {
            this.cheeseLogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cheese> ReadAll()
        {
            return this.cheeseLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Cheese Read(int id)
        {
            return this.cheeseLogic.GetOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Cheese cheese)
        {
            this.cheeseLogic.Create(cheese);
            this.hub.Clients.All.SendAsync("CheeseCreated", cheese);
        }

        [HttpPut]
        public void Put([FromBody] Cheese cheese)
        {
            this.cheeseLogic.Update(cheese);
            this.hub.Clients.All.SendAsync("CheeseUpdated", cheese);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cheeseToDelete = this.cheeseLogic.GetOne(id);
            this.cheeseLogic.Delete(id);
            this.hub.Clients.All.SendAsync("CheeseDeleted", cheeseToDelete);
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
