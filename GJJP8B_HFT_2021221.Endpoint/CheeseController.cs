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
    }
}
