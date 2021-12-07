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

        [Route("ReadAll")]
        [HttpGet]
        public IEnumerable<Buyer> ReadAll()
        {
            return buyerLogic.GetAll();
        }

        [Route("Read/{id}")]
        [HttpGet]
        public Buyer Read(int id)
        {
            return buyerLogic.GetBuyerById(id);
        }

        [Route("Create/{newBuyer}")]
        [HttpPost]
        public void Create(Buyer newBuyer)
        {
            buyerLogic.AddBuyer(newBuyer);
        }

        [Route("ChangeBuyerName/{id}/{newName}")]
        [HttpPut]
        public void ChangeBuyerName(int id, string newName)
        {
            buyerLogic.ChangeBuyerName(id, newName);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            buyerLogic.DeleteBuyerById(id);
        }

        [Route("ChangeMoney/{id}/{price}")]
        public void ChangeMoney(int id, float price)//for the sake of consistency, the new money is called price as well
        {
            buyerLogic.ChangeMoney(id, price);
        }

        [Route("CanAffordGivenCheese/{id}/{cheeseid}")]
        [HttpGet]
        public bool CanAfford(int id, int cheeseid)
        {
            return buyerLogic.CanAffordGivenCheese(id, cheeseid);
        }

        [Route("ListBuyerWhoCanAffordGivenCheese/{cheeseid}")]
        [HttpGet]
        public IEnumerable<Buyer> ListBuyersWhoCanAffordGivenCheese(int cheeseid)
        {
            return buyerLogic.ListBuyersWhoCanAffordGivenCheese(cheeseid);
        }

        [Route("ListBuyersWithGivenCheesePreference/{id}")]
        [HttpGet]
        public IEnumerable<Buyer> ListBuyersWithGivenCheesePreference(int id)
        {
            return buyerLogic.ListBuyersWithGivenCheesePreference(id);
        }
    }
}
