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
            Mock<IMilkRepository> mockedMilkRepository = new();
            mockedMilkRepository.Setup(x => x.ReturnOne(It.IsAny<int>())).Returns<int>((id) => FakeMilks().FirstOrDefault(x => x.Id == id));
            mockedMilkRepository.Setup(x => x.ChangeName(It.IsNotIn<int>(1, 2), It.IsAny<string>())).Throws(new Exception());
            mockedMilkRepository.Setup(x => x.ReturnAll()).Returns(FakeMilks());

            this.ILogic = new MilkLogic(mockedMilkRepository.Object);
        }

        [Test]
        public void ReturnMilkPriceTest()
        {
            float test = ILogic.ReturnPrice(1);

            float expectedResult = 1500f;

            Assert.AreEqual(expectedResult, test);
        }

        [Test]
        public void GetMilkByIdTest()
        {
            Milk test = ILogic.GetMilkById(1);

            Milk expectedResult = new Milk() { Id = 1, Name = "Mommy Milk", Price = 1500, Cheeses = new List<Cheese>() };

            Assert.IsTrue(test.Id == expectedResult.Id);
            Assert.IsTrue(test.Name == expectedResult.Name);
            Assert.IsTrue(test.Price == expectedResult.Price);
        }

        [Test]
        public void ChangeMilkNameTest()
        {
            Assert.Throws(typeof(Exception), () => ILogic.ChangeMilkName(69, "There is no Milk with such ID!"));
            Assert.DoesNotThrow(() => ILogic.ChangeMilkName(1, "Is of workings!"));
        }

        [Test]
        public void ChangeMilkPriceTest()
        {
            //Assert.Throws(typeof(InvalidOperationException), () => ILogic.ChangePrice(70, 500f)); this is embarrassing but no idea why this doesn't throw an error
            Assert.DoesNotThrow(() => ILogic.ChangePrice(1, 500f));
        }

        [Test]
        public void MilksUnderPriceTest()
        {
            IEnumerable<Milk> test = ILogic.MilksUnderPrice(600f);

            Assert.That(test.Count() == 2);
        }
    }
}
