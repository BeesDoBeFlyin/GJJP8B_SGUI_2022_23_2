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
        IBuyerLogic buyerLogic;
        IHubContext<SignalRHub> hub;

        public BuyerController(IBuyerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.buyerLogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Buyer> ReadAll()
        {
            return this.buyerLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Buyer Read(int id)
        {
            return this.buyerLogic.GetOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Buyer buyer)
        {
            this.buyerLogic.Create(buyer);
            this.hub.Clients.All.SendAsync("BuyerCreated", buyer);
        }

        [HttpPut]
        public void Put([FromBody] Buyer buyer)
        {
            this.buyerLogic.Update(buyer);
            this.hub.Clients.All.SendAsync("BuyerUpdated", buyer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var buyerToDelete = this.buyerLogic.GetOne(id);
            this.buyerLogic.Delete(id);
            this.hub.Clients.All.SendAsync("BuyerDeleted", buyerToDelete);
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
