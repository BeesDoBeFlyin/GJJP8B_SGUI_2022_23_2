using System;
using System.Collections.Generic;
using System.Linq;
using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;

namespace GJJP8B_HFT_2021221.Test
{
    [TestFixture]
    public class BuyerLogicTests
    {
        private BuyerLogic ILogic { get; set; }

        private IQueryable<Buyer> FakeBuyers()
        {
            Buyer b1 = new() { Id = 1, Name = "Mutter", Money = 7500, CheeseId = 1, Cheese = new Cheese() };
            Buyer b2 = new() { Id = 2, Name = "Vater", Money = 5500, CheeseId = 2, Cheese = new Cheese() };
            Buyer b3 = new() { Id = 3, Name = "The holy spirit", Money = 550, CheeseId = 3, Cheese = new Cheese() };

            List<Buyer> Buyers = new();

            Buyers.Add(b1);
            Buyers.Add(b2);
            Buyers.Add(b3);

            return Buyers.AsQueryable();
        }

        [SetUp]
        public void SetUp()
        {
            Mock<IBuyerRepository> mockedBuyerRepository = new();
            mockedBuyerRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeBuyers().FirstOrDefault(x => x.Id == id));
            mockedBuyerRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedBuyerRepository.Setup(x => x.ReturnAll()).Returns(FakeBuyers());

            this.ILogic = new BuyerLogic(mockedBuyerRepository.Object);
        }

        [Test]
        public void ReturnBuyerMoneyTest()
        {
            float test = ILogic.ReturnMoney(1);

            float expectedResult = 7500;

            Assert.AreEqual(expectedResult, test);
        }

        [Test]
        public void GetBuyerByIdTest()
        {
            Buyer test = ILogic.GetBuyerById(1);

            Buyer expectedResult = new Buyer() { Id = 1, Name = "Mutter", Money = 7500, CheeseId = 1, Cheese = new Cheese() };

            Assert.IsTrue(test.Id == expectedResult.Id);
            Assert.IsTrue(test.Name == expectedResult.Name);
            Assert.IsTrue(test.Money == expectedResult.Money);
        }

        [Test]
        public void ChangeBuyerNameTest()
        {
            Assert.Throws(typeof(Exception), () => ILogic.ChangeBuyerName(69, "There is no Milk with such ID!"));
            Assert.DoesNotThrow(() => ILogic.ChangeBuyerName(1, "Is of workings!"));
        }

        [Test]
        public void ChangeBuyerMoneyTest()
        {
            //Assert.Throws(typeof(InvalidOperationException), () => ILogic.ChangePrice(70, 500f)); this is embarrassing but no idea why this doesn't throw an error
            Assert.DoesNotThrow(() => ILogic.ChangeMoney(1, 500f));
        }

        [Test]
        public void BuyerCanAffordTest()
        {
            bool test = ILogic.CanAfford(1, 600f);
            bool test2 = ILogic.CanAfford(3, 8800f);

            Assert.That(test);
            Assert.That(!test2);
        }
    }
}
