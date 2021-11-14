using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;

namespace GJJP8B_HFT_2021221.Repository
{
    public class MilkRepository : Repository<Milk>, IMilkRepository
    {
        public MilkRepository(CheeseContext context) : base(context)
        {

        }

        public void ChangeName(int id, string newName)
        {
            var milk = this.ReturnOne(id);
            if (milk == null)
            {
                throw new InvalidOperationException("There is no record with the given id!");
            }
            milk.Name = newName;
            this.Context.SaveChanges();
        }

        public void ChangePrice(int id, int newPrice)
        {
            var milk = this.ReturnOne(id);
            if (milk == null)
            {
                throw new InvalidOperationException("There is no record with the given id!");
            }
            milk.Price = newPrice;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Milk obj = this.ReturnOne(id);
            this.Context.Set<Milk>().Remove(obj);
            this.Context.SaveChanges();
        }

        public override void Insert(Milk entity)
        {
            this.Context.Set<Milk>().Add(entity);
            this.Context.SaveChanges();
        }

        public override Milk ReturnOne(int id)
        {
            return this.ReturnAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
