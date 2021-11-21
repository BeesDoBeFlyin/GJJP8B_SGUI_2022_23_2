using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using NUnit.Framework;

namespace GJJP8B_HFT_2021221.Test
{
    [TestFixture]
    public class CheeseLogicTests
    {
        private CheeseLogic ILogic { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            this.ILogic = new CheeseLogic();

            this.ILogic.AddCheese(new Cheese()
            {
                Name = "Test Cheese #0",
                Price = 2500
            });
        }
    }
}
