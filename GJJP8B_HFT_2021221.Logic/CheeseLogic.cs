using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public class CheeseLogic : ICheeseLogic
    { 
        private IRepository<Cheese> repository;
        private IRepository<Milk> milkRepo;

        public CheeseLogic(IRepository<Cheese> cheeseRepository, IRepository<Milk> milkRepository)
        {
            this.repository = cheeseRepository;
            this.milkRepo = milkRepository;
        }

        public void Create(Cheese cheese)
        {
            this.repository.Create(cheese);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Cheese GetOne(int id)
        {
            return this.repository.ReturnOne(id);
        }

        public IQueryable<Cheese> GetAll()
        {
            return this.repository.ReturnAll();
        }

        public void Update(Cheese cheese)
        {
            this.repository.Update(cheese);
        }

        public IEnumerable<Cheese> CheesesUnderPrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price < price);

            return cheeses;
        }

        public IEnumerable<Cheese> CheesesAtPrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price == price);

            return cheeses;
        }

        public IEnumerable<Cheese> CheesesAbovePrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price > price);

            return cheeses;
        }

        public IEnumerable MadeOf(int id)
        {
            var madeOf = from a in milkRepo.ReturnAll()
                         join b in repository.ReturnAll() on a.Id equals b.MilkId
                         where (b.MilkId == id)
                         select new Milk
                         {
                             Name = a.Name,
                             Price = a.Price,
                             Id = a.Id,
                             CheesesNonDb = a.CheesesNonDb
                         };

            return madeOf as IEnumerable;
        }

        public IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(int id)
        {
            var cheeses = from a in repository.ReturnAll()
                          join b in milkRepo.ReturnAll() on a.MilkId equals b.Id
                          where (b.Id == id)
                          select a;

            return cheeses as IEnumerable<Cheese>;
        }

        public IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price)
        {
            var cheeses = from a in repository.ReturnAll()
                          join b in milkRepo.ReturnAll() on a.MilkId equals b.Id
                          where (b.Price < price)
                          select a;

            return cheeses as IEnumerable<Cheese>;
        }
    }
}
