using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<SignalRHub> hub;

        public BuyerController(IBuyerLogic buyerLogic, IHubContext<SignalRHub> hub)
        {
            this.buyerLogic = buyerLogic;
            this.hub = hub;
        }

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
            hub.Clients.All.SendAsync("BuyerCreated", newBuyer);
        }

        [Route("ChangeBuyerName/{id}/{newName}")]
        [HttpPut]
        public void ChangeBuyerName(int id, string newName)
        {
            buyerLogic.ChangeBuyerName(id, newName);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Buyer buyerToDelete = buyerLogic.GetBuyerById(id);
            buyerLogic.DeleteBuyerById(id);
            hub.Clients.All.SendAsync("CheeseDeleted", buyerToDelete);
        }

        [Route("ChangeMoney/{id}/{price}")]
        [HttpPut]
        public void ChangeMoney(int id, float price)//for the sake of consistency, the new money is called price as well
        {
            buyerLogic.ChangeMoney(id, price);
        }

        [Route("ChangeCheeseId/{id}/{cheeseId}")]
        [HttpPut]
        public void ChangePreferredCheesee(int id, int cheeseeId)
        {
            buyerLogic.ChangePreferredCheese(id, cheeseeId);
        }

        [Route("EditAll/{id}/{name}-{money}-{cheeseId}")]
        [HttpPut("editAll")]
        public void EditBuyer(Buyer buyer)
        {
            buyerLogic.ChangeBuyerName(buyer.Id, buyer.Name);
            buyerLogic.ChangeMoney(buyer.Id, buyer.Money);
            buyerLogic.ChangePreferredCheese(buyer.Id, buyer.CheeseId);
        }

        [Route("CanAffordGivenCheese/{id}/{cheeseid}")]
        [HttpGet]
        public bool CanAfford(int id, int cheeseid)
        {
            return buyerLogic.CanAffordGivenCheese(id, cheeseid);
        }

        [Route("ListBuyersWhoCanAffordPreferredCheese")]
        [HttpGet]
        public IEnumerable<Buyer> ListBuyersWhoCanAffordGivenCheese()
        {
            return buyerLogic.ListBuyersWhoCanAffordPreferredCheese();
        }

        [Route("ListBuyersWithGivenCheesePreference/{id}")]
        [HttpGet]
        public IEnumerable<Buyer> ListBuyersWithGivenCheesePreference(int id)
        {
            return buyerLogic.ListBuyersWithGivenCheesePreference(id);
        }
    }
}
