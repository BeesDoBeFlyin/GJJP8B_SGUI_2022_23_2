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
    public class MilkLogicTests
    {
        private MilkLogic ILogic { get; set; }

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

            this.ILogic = new MilkLogic(mockedMilkRepository.Object);
        }

        [Test]
        public void GetOneTest()
        {
            Milk test = ILogic.GetOne(1);

            Milk expectedResult = new() { Id = 1, Name = "Mommy Milk", Price = 1500, CheesesNonDb = new List<Cheese>() };

            Assert.AreEqual(expectedResult, test);
        }

        [Test]
        public void UpdateMilkTest()
        {
            Milk mTest = new() { Id = 69, Name = "Mommy Milk", Price = 1500, CheesesNonDb = new List<Cheese>() };
            Assert.Throws(typeof(Exception), () => ILogic.Update(mTest));
            Milk mTest2 = new() { Id = 1, Name = "Mommy Milk", Price = 1500, CheesesNonDb = new List<Cheese>() };
            Assert.DoesNotThrow(() => ILogic.Update(mTest2));
        }

        [Test]
        public void MilksUnderPriceTest()
        {
            IEnumerable<Milk> test = ILogic.MilksUnderPrice(600f);

            Assert.That(test.Count() == 2);
        }
    }
}
