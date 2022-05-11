using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Endpoint
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        IBuyerLogic buyerLogic;
        ICheeseLogic cheeseLogic;
        IMilkLogic milkLogic;

        public NonCrudController(IBuyerLogic buyerLogic, IMilkLogic milkLogic, ICheeseLogic cheeseLogic)
        {
            this.buyerLogic = buyerLogic;
            this.milkLogic = milkLogic;
            this.cheeseLogic = cheeseLogic;
        }

        [HttpGet]
        public IEnumerable<Buyer> ListBuyersWithCheese()
        {
            return buyerLogic.ListBuyersWithCheese();
        }

        [HttpGet]
        public IEnumerable<Cheese> ListCheesesWithMilk()
        {
            return cheeseLogic.ListCheesesWithMilk();
        }
        
        [HttpGet]
        public IEnumerable<Milk> ListMilksId()
        {
            return milkLogic.ShowMilksId();
        }
    }
}
