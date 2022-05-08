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
        private IRepository<Buyer> repository;
        private IRepository<Cheese> cheeseRepo;

        public BuyerLogic(IRepository<Buyer> buyerRepository, IRepository<Cheese> cheeseRepository)
        {
            this.repository = buyerRepository;
            this.cheeseRepo = cheeseRepository;
        }

        public void Create(Buyer buyer)
        {
            this.repository.Create(buyer);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Buyer GetOne(int id)
        {
            return this.repository.ReturnOne(id);
        }

        public IQueryable<Buyer> GetAll()
        {
            return this.repository.ReturnAll();
        }

        public void Update(Buyer buyer)
        {
            this.repository.Update(buyer);
        }

        public bool CanAffordGivenCheese(int id, int cheeseid)
        {
            return (repository.ReturnOne(id).Money > cheeseRepo.ReturnOne(id).Price);
        }

        public IEnumerable<Buyer> ListBuyersWhoCanAffordPreferredCheese()
        {
            IEnumerable<Buyer> buyers = from a in repository.ReturnAll()
                         join b in cheeseRepo.ReturnAll() on a.CheeseId equals b.Id
                         where (a.Money > b.Price)
                         select a;
            
            return buyers;
        }

        public IEnumerable<Buyer> ListBuyersWithGivenCheesePreference(int id)
        {
            IEnumerable<Buyer> buyers = from a in repository.ReturnAll()
                                        join b in cheeseRepo.ReturnAll() on a.CheeseId equals b.Id
                                        where (a.CheeseId == id)
                                        select a;
            return buyers;
        }
    }
}
