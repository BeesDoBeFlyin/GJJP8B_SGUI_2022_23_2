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
            //this.ILogic = new CheeseLogic();

            this.ILogic.AddCheese(new Cheese()
            {
                Name = "Test Cheese #0",
                Price = 2500,
                MilkId = 1
            });
            
            this.ILogic.AddCheese(new Cheese()
            {
                Name = "Test Cheese #1",
                Price = 1950,
                MilkId = 2
            });
        }

        [Test]
        public void AddCheeseTest()
        {
            string newName = "Test Cheese #5500";
            int newPrice = 5500;
            int milkid = 1;

            ILogic.AddCheese(new Cheese()
            {
                Name = newName,
                Price = newPrice,
                MilkId = milkid
            });

            //Assert.That(ILogic.GetAll()[ILogic.CheeseCount - 1].Name, Is.EqualTo(newName));
            //Assert.That(ILogic.GetAll()[ILogic.CheeseCount - 1].Price, Is.EqualTo(newPrice));
            //Assert.That(ILogic.GetAll()[ILogic.CheeseCount - 1].MilkId, Is.EqualTo(milkid));
        }

        [TestCase(1, "")]
        [TestCase(2, null)]
        [TestCase(3, "")]
        public void ChangeCheeseNameTestForNullAndEmptyName(int id, string input)
        {
            Assert.That(() => ILogic.ChangeCheeseName(id, input), Throws.TypeOf<Exception>());
        }

        [TestCase(2, "Test Cheese #0")]
        public void ChangeMilkNameTestForExistingName(int id, string input)
        {
            Assert.That(() => ILogic.ChangeCheeseName(id, input), Throws.TypeOf<Exception>());
        }

        [TestCase(1, "HHObwwS8Zr21tnxwEG115tQnFrrwQ1J13v050ZAmpREoCr64hBHJkooRPx0TVb9E8DUTwVIkrAqGMR0p9")]
        public void ChangeCheeseNameTestForCharacterLength(int id, string input)
        {
            Assert.That(() => ILogic.ChangeCheeseName(id, input), Throws.TypeOf<Exception>());
        }
    }
}
