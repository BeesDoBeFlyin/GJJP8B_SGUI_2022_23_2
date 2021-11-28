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

        [Route("ReadAll")]
        [HttpGet]
        public IEnumerable<Milk> ReadAll()
        {
            return milkLogic.GetAll();
        }

        [Route("Read/{id}")]
        [HttpGet]
        public Milk Read(int id)
        {
            return milkLogic.GetMilkById(id);
        }

        [Route("Create/{newMilk}")]
        [HttpPost]
        public void Create(Milk newMilk)
        {
            milkLogic.AddMilk(newMilk);
        }

        [Route("ChangeMilkName/{id}/{name}")]
        [HttpPut]
        public void ChangeMilkName(int id, string newName)
        {
            milkLogic.ChangeMilkName(id, newName);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            milkLogic.DeleteMilkById(id);
        }
    }
}
