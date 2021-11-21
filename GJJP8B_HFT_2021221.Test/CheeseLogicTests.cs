using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using NUnit.Framework;
using System;

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
            
            this.ILogic.AddCheese(new Cheese()
            {
                Name = "Test Cheese #1",
                Price = 1950
            });
        }

        [Test]
        public void AddCheeseTest()
        {
            string newName = "Test Milk #5500";
            int newPrice = 5500;

            ILogic.AddCheese(new Cheese()
            {
                Name = newName,
                Price = newPrice
            });

            Assert.That(ILogic.GetAll()[ILogic.CheeseCount - 1].Name, Is.EqualTo(newName));
            Assert.That(ILogic.GetAll()[ILogic.CheeseCount - 1].Price, Is.EqualTo(newPrice));
        }

        [TestCase(1, "")]
        [TestCase(2, null)]
        [TestCase(3, "")]
        public void ChangeCheeseNameTestForNullAndEmptyName(int id, string input)
        {
            Assert.That(() => ILogic.ChangeCheeseName(id, input), Throws.TypeOf<Exception>());
        }
    }
}
