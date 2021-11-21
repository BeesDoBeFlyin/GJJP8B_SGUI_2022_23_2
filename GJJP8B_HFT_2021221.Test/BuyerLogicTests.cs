using System;
using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using NUnit.Framework;

namespace GJJP8B_HFT_2021221.Test
{
    [TestFixture]
    public class BuyerLogicTests
    {
        private BuyerLogic ILogic { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            this.ILogic = new BuyerLogic();

            ILogic.AddBuyer(new Buyer()
            {
                Name = "Test Buyer #0",
                Money = 5500
            });

            ILogic.AddBuyer(new Buyer()
            {
                Name = "Test Buyer #1",
                Money = 7850
            });
        }

        [Test]
        public void AddBuyerTest()
        {
            string newName = "Test Buyer #5500";
            int newPrice = 5500;

            ILogic.AddBuyer(new Buyer()
            {
                Name = newName,
                Money = newPrice
            });

            Assert.That(ILogic.GetAll()[ILogic.BuyerCount - 1].Name, Is.EqualTo(newName));
            Assert.That(ILogic.GetAll()[ILogic.BuyerCount - 1].Money, Is.EqualTo(newPrice));
        }

        [TestCase(1, "")]
        [TestCase(2, null)]
        [TestCase(3, "")]
        public void ChangeMilkNameTestForNullAndEmptyName(int id, string input)
        {
            Assert.That(() => ILogic.ChangeBuyerName(id, input), Throws.TypeOf<Exception>());
        }
    }
}
