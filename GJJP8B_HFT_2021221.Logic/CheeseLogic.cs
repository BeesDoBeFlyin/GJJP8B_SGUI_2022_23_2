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
        private ICheeseRepository repository;
        private IMilkRepository milkRepo;

        public CheeseLogic(ICheeseRepository cheeseRepository, IMilkRepository milkRepository)
        {
            this.repository = cheeseRepository;
            this.milkRepo = milkRepository;
        }

        public Cheese GetCheeseById(int id)
        {
            return repository.ReturnOne(id);
        }

        public void AddCheese(Cheese ch)
        {
            repository.Insert(ch);
        }

        public IQueryable<Cheese> GetAll()
        {
            return repository.ReturnAll();
        }

        public void ChangeCheeseName(int id, string newName)
        {
            repository.ChangeName(id, newName);
        }

        public void DeleteCheeseById(int id)
        {
            repository.Delete(id);
        }

        public void ChangePrice(int id, float newPrice)
        {
            repository.ChangePrice(id, newPrice);
        }

        public void ChangeMilk(int id, int newMilkId)
        {
            repository.ChangeMilk(id, newMilkId);
        }

        public float ReturnPrice(int id)
        {
            return repository.ReturnOne(id).Price;
        }

        public IEnumerable<Cheese> CheesesUnderPrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price < price);

            return cheeses.AsQueryable<Cheese>();
        }

        public IEnumerable<Cheese> CheesesAtPrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price == price);

            return cheeses.AsQueryable<Cheese>();
        }

        public IEnumerable<Cheese> CheesesAbovePrice(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Price > price);

            return cheeses.AsQueryable<Cheese>();
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
                             Cheeses = a.Cheeses
                         };
            return madeOf as IEnumerable;
        }

        public IEnumerable<Cheese> ListCheesesMadeOfGivenMilk(int id)
        {
            var cheeses = from a in milkRepo.ReturnAll()
                          join b in repository.ReturnAll() on a.Id equals b.MilkId
                          where (id == a.Id)
                          select b;

            return cheeses.AsEnumerable<Cheese>();
        }

        public IEnumerable<Cheese> ListCheesesWithMaterialCheaperThanGiven(float price)
        {
            IEnumerable<Cheese> cheeses = repository.ReturnAll().Where(x => x.Milk.Price < price);

            return cheeses;
        }
    }
}
