using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public class CheeseLogic : ICheeseLogic
    { 

        private ICheeseRepository repository;

        public CheeseLogic(ICheeseRepository cheeseRepository)
        {
            repository = cheeseRepository;
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

        public IQueryable<Cheese> CheesesUnderPrice(float price)
        {
            List<Cheese> cheeses = new List<Cheese>();
            foreach (var item in repository.ReturnAll())
            {
                if (item.Price < price)
                    cheeses.Add(item);
            }

            return cheeses.AsQueryable<Cheese>();
        }
    }
}
