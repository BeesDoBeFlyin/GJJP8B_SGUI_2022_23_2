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
    public class MilkController : ControllerBase
    {
        IMilkLogic milkLogic;
        IHubContext<SignalRHub> hub;

        public MilkController(ICheeseLogic logic, IHubContext<SignalRHub> hub)
        {
            this.milkLogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Milk> ReadAll()
        {
            return this.milkLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Milk Read(int id)
        {
            return this.milkLogic.GetOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Milk milk)
        {
            this.milkLogic.Create(milk);
            this.hub.Clients.All.SendAsync("MilkCreated", milk);
        }

        [HttpPut]
        public void Put([FromBody] Milk milk)
        {
            this.milkLogic.Update(milk);
            this.hub.Clients.All.SendAsync("MilkUpdated", milk);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var milkToDelete = this.milkLogic.GetOne(id);
            this.milkLogic.Delete(id);
            this.hub.Clients.All.SendAsync("MilkDeleted", milkToDelete);
        }

        [Route("UnderPrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksUnderPrce(float price)
        {
            return milkLogic.MilksUnderPrice(price);
        }

        [Route("AtPrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksAtPricePoint(float price)
        {
            return milkLogic.MilksAtPricePoint(price);
        }
        
        [Route("AbovePrice/{price}")]
        [HttpGet]
        public IEnumerable<Milk> GetMilksAbovePrice(float price)
        {
            return milkLogic.MilksAbovePrice(price);
        }
    }
}
