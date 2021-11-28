using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public IEnumerable<Cheese> ReadAll()
        {
            return cheeseLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Cheese Read(int id)
        {
            return cheeseLogic.GetCheeseById(id);
        }

        [HttpPost("{newCheese}")]
        public void Create(Cheese newCheese)
        {
            cheeseLogic.AddCheese(newCheese);
        }

        [HttpPut("{id,newName}")]
        public void ChangeCheeseName(int id, string newName)
        {
            cheeseLogic.ChangeCheeseName(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cheeseLogic.DeleteCheeseById(id);
        }
    }
}
