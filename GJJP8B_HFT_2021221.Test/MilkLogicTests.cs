using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using NUnit.Framework;

namespace GJJP8B_HFT_2021221.Test
{
    [TestFixture]
    public class MilkLogicTests
    {
        private IMilkLogic ILogic { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ILogic = new MilkLogic();

            this.ILogic.AddMilk(new Milk()
            {
                Name = "Test Milk #0",
                Price = 500
            });

            this.ILogic.AddMilk(new Milk()
            {
                Name = "Test Milk #1",
                Price = 1500
            });
        }

        [Test]
        public void AddMilk()
        {
            string newName = "Test Milk #5500";
            int newPrice = 5500;

            ILogic.AddMilk(new Milk()
            {
                Name = newName,
                Price = newPrice
            });

            Assert.That(ILogic.GetAll()[ILogic.MilkCount - 1].Name, Is.EqualTo(newName));
            Assert.That(ILogic.GetAll()[ILogic.MilkCount - 1].Price, Is.EqualTo(newPrice));
        }
    }
}
