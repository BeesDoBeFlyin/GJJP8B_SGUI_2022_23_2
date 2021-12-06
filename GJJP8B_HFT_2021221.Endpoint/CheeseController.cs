using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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

        public CheeseController(ICheeseLogic cheeseLogic)
        {
            this.cheeseLogic = cheeseLogic;
        }

        [Route("ReadAll")]
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
        }

        [Route("ChangeCheeseName/{id}/{newName}")]
        [HttpPut]
        public void ChangeCheeseName(int id, string newName)
        {
            cheeseLogic.ChangeCheeseName(id, newName);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            cheeseLogic.DeleteCheeseById(id);
        }

        [Route("ChangePrice/{id}/{price}")]
        [HttpPut]
        public void ChangePrice(int id, float price)
        {
            cheeseLogic.ChangePrice(id, price);
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

        [Route("ListCheesesMadeOfGivenMilk/{milk}")]
        [HttpGet]
        public IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(Milk milk)
        {
            return cheeseLogic.ListCheesesMadeOfGivenMilk(milk);
        }

        [Route("ListCheesesWithMaterialCheaperThanGiven/{price}")]
        [HttpGet]
        public IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price)
        {
            return cheeseLogic.ListCheesesWithMaterialCheaperThanGiven(price);
        }
    }
}
