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
    public class MilkController : ControllerBase
    {
        private IMilkLogic milkLogic;

        public MilkController(IMilkLogic milkLogic)
        {
            this.milkLogic = milkLogic;
        }

        [HttpGet]
        public IEnumerable<Milk> ReadAll()
        {
            return milkLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Milk Read(int id)
        {
            return milkLogic.GetMilkById(id);
        }

        [HttpPost("{newMilk}")]
        public void Create(Milk newMilk)
        {
            milkLogic.AddMilk(newMilk);
        }

        [HttpPut("{id,newName}")]
        public void ChangeMilkName(int id, string newName)
        {
            milkLogic.ChangeMilkName(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            milkLogic.DeleteMilkById(id);
        }
    }
}
