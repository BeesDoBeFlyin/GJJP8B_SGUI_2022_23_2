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
        private MilkLogic MLogic { get; set; }

        private IQueryable<Cheese> FakeCheeses()
        {
            Cheese c1 = new() { Id = 1, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };
            Cheese c2 = new() { Id = 2, Name = "Trollface", Price = 2500, MilkId = 2, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };
            Cheese c3 = new() { Id = 3, Name = "Ohyes", Price = 850, MilkId = 3, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };

            List<Cheese> FakeCheeses = new List<Cheese>();

            FakeCheeses.Add(c1);
            FakeCheeses.Add(c2);
            FakeCheeses.Add(c3);

            return FakeCheeses.AsQueryable();
        }

        private IQueryable<Milk> FakeMilks()
        {
            Milk m1 = new() { Id = 1, Name = "Mommy Milk", Price = 1500, CheesesNonDb = new List<Cheese>() };
            Milk m2 = new() { Id = 2, Name = "I'm advised to continue this meme no further", Price = 500, CheesesNonDb = new List<Cheese>() };
            Milk m3 = new() { Id = 2, Name = "Ohno", Price = 250, CheesesNonDb = new List<Cheese>() };

            List<Milk> milks = new();

            milks.Add(m1);
            milks.Add(m2);
            milks.Add(m3);

            return milks.AsQueryable();
        }

        [SetUp]
        public void SetUp()
        {
            Mock<IRepository<Milk>> mockedMilkRepository = new();
            mockedMilkRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeMilks().FirstOrDefault(x => x.Id == id));
            mockedMilkRepository.Setup(x => x.ReturnAll()).Returns(FakeMilks());

            this.MLogic = new MilkLogic(mockedMilkRepository.Object);

            Mock<IRepository<Cheese>> mockedCheeseRepository = new();
            mockedCheeseRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeCheeses().FirstOrDefault(x => x.Id == id));
            mockedCheeseRepository.Setup(x => x.ReturnAll()).Returns(FakeCheeses());

            this.ILogic = new CheeseLogic(mockedCheeseRepository.Object, mockedMilkRepository.Object);
        }

        [Test]
        public void GetOneCheeseTest()
        {
            Cheese test = ILogic.GetOne(1);

            Cheese expectedResult = new() { Id = 1, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };

            Assert.AreEqual(expectedResult, test);
            Assert.IsTrue(test.Id == expectedResult.Id);
            Assert.IsTrue(test.Name == expectedResult.Name);
            Assert.IsTrue(test.Price == expectedResult.Price);
        }

        [Test]
        public void UpdateCheeseTest()
        {
            Cheese cTest = new() { Id = 50, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };
            Assert.Throws(typeof(Exception), () => ILogic.Update(cTest));
            Cheese cTest2 = new() { Id = 1, Name = "Don't ask", Price = 1500, MilkId = 1, Milk = new Milk(), BuyersNonDb = new List<Buyer>() };
            Assert.DoesNotThrow(() => ILogic.Update(cTest2));
        }

        [Test]
        public void CheeseUnderPriceTest()
        {
            IEnumerable<Cheese> test = ILogic.CheesesUnderPrice(1200f);

            Assert.That(test.Count() == 1);
        }
    }
}
