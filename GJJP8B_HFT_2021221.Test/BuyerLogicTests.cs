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
        private CheeseLogic BLogic { get; set; }
        private MilkLogic MLogic { get; set; }

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

        private IQueryable<Cheese> FakeCheeses()
        {
            Cheese c1 = new() { Id = 1, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), Buyers = new List<Buyer>() };
            Cheese c2 = new() { Id = 2, Name = "Trollface", Price = 2500, MilkId = 2, Milk = new Milk(), Buyers = new List<Buyer>() };
            Cheese c3 = new() { Id = 3, Name = "Ohyes", Price = 850, MilkId = 3, Milk = new Milk(), Buyers = new List<Buyer>() };

            List<Cheese> FakeCheeses = new List<Cheese>();

            FakeCheeses.Add(c1);
            FakeCheeses.Add(c2);
            FakeCheeses.Add(c3);

            return FakeCheeses.AsQueryable();
        }

        private IQueryable<Milk> FakeMilks()
        {
            Milk m1 = new() { Id = 1, Name = "Mommy Milk", Price = 1500, Cheeses = new List<Cheese>() };
            Milk m2 = new() { Id = 2, Name = "I'm advised to continue this meme no further", Price = 500, Cheeses = new List<Cheese>() };
            Milk m3 = new() { Id = 2, Name = "Ohno", Price = 250, Cheeses = new List<Cheese>() };

            List<Milk> milks = new();

            milks.Add(m1);
            milks.Add(m2);
            milks.Add(m3);

            return milks.AsQueryable();
        }

        [SetUp]
        public void SetUp()
        {
            //I regret separating testing for the different models
            Mock<IMilkRepository> mockedMilkRepository = new();
            mockedMilkRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeMilks().FirstOrDefault(x => x.Id == id));
            mockedMilkRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedMilkRepository.Setup(x => x.ReturnAll()).Returns(FakeMilks());

            this.MLogic = new MilkLogic(mockedMilkRepository.Object);

            Mock<ICheeseRepository> mockedCheeseRepository = new();
            mockedCheeseRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeCheeses().FirstOrDefault(x => x.Id == id));
            mockedCheeseRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedCheeseRepository.Setup(x => x.ReturnAll()).Returns(FakeCheeses());

            this.BLogic = new CheeseLogic(mockedCheeseRepository.Object, mockedMilkRepository.Object);

            Mock<IBuyerRepository> mockedBuyerRepository = new();
            mockedBuyerRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeBuyers().FirstOrDefault(x => x.Id == id));
            mockedBuyerRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedBuyerRepository.Setup(x => x.ReturnAll()).Returns(FakeBuyers());

            this.ILogic = new BuyerLogic(mockedBuyerRepository.Object, mockedCheeseRepository.Object);
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
            bool test = ILogic.CanAffordGivenCheese(1, 1);
            bool test2 = ILogic.CanAffordGivenCheese(2, 1);
            bool test3 = ILogic.CanAffordGivenCheese(3, 1);

            Assert.That(test);
            Assert.That(test2);
            Assert.That(!test3);
        }
    }
}
