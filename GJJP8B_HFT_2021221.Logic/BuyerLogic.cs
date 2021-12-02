using GJJP8B_HFT_2021221.Models;
using GJJP8B_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public class BuyerLogic : IBuyerLogic
    {
        private IBuyerRepository repository;

        public BuyerLogic(IBuyerRepository buyerRepository)
        {
            repository = buyerRepository;
        }

        public Buyer GetBuyerById(int id)
        {
            return repository.ReturnOne(id);
        }

        public void AddBuyer(Buyer buy)
        {
            repository.Insert(buy);
        }

        public IQueryable<Buyer> GetAll()
        {
            return repository.ReturnAll();
        }

        public void ChangeBuyerName(int id, string newName)
        {
            repository.ChangeName(id, newName);
        }

        public void DeleteBuyerById(int id)
        {
            repository.Delete(id);
        }

        public void ChangeMoney(int id, float newMoney)
        {
            repository.ChangeMoney(id, newMoney);
        }

        public void ChangePreferredCheese(int id, int newCheeseId)
        {
            repository.ChangePreferredCheese(id, newCheeseId);
        }

        public float ReturnMoney(int id)
        {
            return repository.ReturnOne(id).Money;
        }

        public bool CanAfford(int id, float price)
        {
            return (ReturnMoney(id) > price);
        }
    }
}
