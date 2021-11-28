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
    public class BuyerController : ControllerBase
    {
        private IBuyerLogic buyerLogic;

        public BuyerController(IBuyerLogic buyerLogic)
        {
            this.buyerLogic = buyerLogic;
        }

        [HttpGet]
        public IEnumerable<Buyer> ReadAll()
        {
            return buyerLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Buyer Read(int id)
        {
            return buyerLogic.GetBuyerById(id);
        }

        [HttpPost("{newBuyer}")]
        public void Create(Buyer newBuyer)
        {
            buyerLogic.AddBuyer(newBuyer);
        }

        [HttpPut("{id,newName}")]
        public void ChangeBuyerName(int id, string newName)
        {
            buyerLogic.ChangeBuyerName(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            buyerLogic.DeleteBuyerById(id);
        }
    }
}
