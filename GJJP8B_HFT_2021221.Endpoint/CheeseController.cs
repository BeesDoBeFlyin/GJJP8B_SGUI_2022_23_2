using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        ICheeseLogic cheeseLogic;
        IHubContext<SignalRHub> hub;

        public CheeseController(ICheeseLogic logic, IHubContext<SignalRHub> hub)
        {
            this.cheeseLogic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Cheese> ReadAll()
        {
            return this.cheeseLogic.GetAll();
        }

        [HttpGet("{id}")]
        public Cheese Read(int id)
        {
            return this.cheeseLogic.GetOne(id);
        }

        [HttpPost]
        public void Create([FromBody] Cheese cheese)
        {
            this.cheeseLogic.Create(cheese);
            this.hub.Clients.All.SendAsync("CheeseCreated", cheese);
        }

        [HttpPut]
        public void Put([FromBody] Cheese cheese)
        {
            this.cheeseLogic.Update(cheese);
            this.hub.Clients.All.SendAsync("CheeseUpdated", cheese);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cheeseToDelete = this.cheeseLogic.GetOne(id);
            this.cheeseLogic.Delete(id);
            this.hub.Clients.All.SendAsync("CheeseDeleted", cheeseToDelete);
        }
    }
}
