using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GJJP8B_HFT_2021221.Test
{
    [TestFixture]
    public class CheeseLogicTests
    {
        private CheeseLogic ILogic { get; set; }

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

        [SetUp]
        public void SetUp()
        {
            Mock<ICheeseRepository> mockedCheeseRepository = new();
            mockedCheeseRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeCheeses().FirstOrDefault(x => x.Id == id));
            mockedCheeseRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedCheeseRepository.Setup(x => x.ReturnAll()).Returns(FakeCheeses());

            this.ILogic = new CheeseLogic(mockedCheeseRepository.Object);
        }

        [Test]
        public void ReturnCheesePriceTest()
        {
            float test = ILogic.ReturnPrice(1);

            float expectedResult = 1500f;

            Assert.AreEqual(expectedResult, test);
        }

        [Test]
        public void GetCheeseByIdTest()
        {
            Cheese test = ILogic.GetCheeseById(1);

            Cheese expectedResult = new Cheese() { Id = 1, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), Buyers = new List<Buyer>() };

            Assert.IsTrue(test.Id == expectedResult.Id);
            Assert.IsTrue(test.Name == expectedResult.Name);
            Assert.IsTrue(test.Price == expectedResult.Price);
        }

        [Test]
        public void ChangeCheeseNameTest()
        {
            Assert.Throws(typeof(Exception), () => ILogic.ChangeCheeseName(69, "There is no Milk with such ID!"));
            Assert.DoesNotThrow(() => ILogic.ChangeCheeseName(1, "Is of workings!"));
        }

        [Test]
        public void ChangeCheesePriceTest()
        {
            //Assert.Throws(typeof(InvalidOperationException), () => ILogic.ChangePrice(70, 500f)); same stuff, different class
            Assert.DoesNotThrow(() => ILogic.ChangePrice(1, 500f));
        }

        [Test]
        public void CheeseUnderPriceTest()
        {
            IQueryable<Cheese> test = ILogic.CheesesUnderPrice(1200f);

            Assert.That(test.Count() == 1);
        }
    }
}
