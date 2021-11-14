using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Models;

namespace GJJP8B_HFT_2021221.Repository
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(CheeseContext context) : base(context)
        {

        }

        public void ChangeMoney(int id, int newMoney)
        {
            var buyer = this.ReturnOne(id);
            if (buyer == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            buyer.Money = newMoney;
            this.Context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var buyer = this.ReturnOne(id);
            if (buyer == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            buyer.Name = newName;
            this.Context.SaveChanges();
        }

        public void ChangePreferredCheese(int id, int newCheeseId)
        {
            var buyer = this.ReturnOne(id);
            if (buyer == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            buyer.CheeseId = newCheeseId;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Buyer obj = this.ReturnOne(id);
            this.Context.Set<Buyer>().Remove(obj);
            this.Context.SaveChanges();
        }

        public override void Insert(Buyer entity)
        {
            this.Context.Set<Buyer>().Add(entity);
            this.Context.SaveChanges();
        }

        public override Buyer ReturnOne(int id)
        {
            return this.ReturnAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
