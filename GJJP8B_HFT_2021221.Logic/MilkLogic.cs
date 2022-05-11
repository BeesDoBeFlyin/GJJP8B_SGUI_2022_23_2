using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GJJP8B_HFT_2021221.Logic
{
    public class MilkLogic : IMilkLogic
    {
        private IRepository<Milk> repository;

        public MilkLogic(IRepository<Milk> milkRepository)
        {
            this.repository = milkRepository;
        }

        public void Create(Milk milk)
        {
            this.repository.Create(milk);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Milk GetOne(int id)
        {
            return this.repository.ReturnOne(id);
        }

        public IQueryable<Milk> GetAll()
        {
            return this.repository.ReturnAll();
        }

        public void Update(Milk milk)
        {
            this.repository.Update(milk);
        }

        public IEnumerable<Milk> ShowMilksId()
        {
            var milks = from milk in repository.ReturnAll()
                        join milk2 in repository.ReturnAll() on milk.Id equals milk2.Id
                        select new Milk
                        {
                            Id = milk.Id,
                            Name = milk2.Name,
                            Price = milk2.Price
                        };
            return milks;
        }
        //public IEnumerable<Milk> MilksUnderPrice(float price)
        //{
        //    IEnumerable<Milk> milks = repository.ReturnAll().Where(x => x.Price < price);

        //    return milks;
        //}

        //public IEnumerable<Milk> MilksAtPricePoint(float price)
        //{
        //    IEnumerable<Milk> milks = repository.ReturnAll().Where(x => x.Price == price);

        //    return milks;
        //}
        
        //public IEnumerable<Milk> MilksAbovePrice(float price)
        //{
        //    IEnumerable<Milk> milks = repository.ReturnAll().Where(x => x.Price > price);

        //    return milks;
        //}
    }
}
