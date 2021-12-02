using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;

namespace GJJP8B_HFT_2021221.Repository
{
    public class CheeseRepository : Repository<Cheese>, ICheeseRepository
    {
        public CheeseRepository(CheeseContext context) : base(context)
        {

        }

        public void ChangeMilk(int id, int newMilkId)
        {
            var cheese = this.ReturnOne(id);
            if (cheese == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            cheese.MilkId = newMilkId;
            this.Context.SaveChanges();
        }

        public void ChangeName(int id, string newName)
        {
            var cheese = this.ReturnOne(id);
            if (cheese == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            cheese.Name = newName;
            this.Context.SaveChanges();
        }

        public void ChangePrice(int id, float newPrice)
        {
            var cheese = this.ReturnOne(id);
            if (cheese == null)
            {
                throw new InvalidOperationException("There is no data with the given id!");
            }
            cheese.Price = newPrice;
            this.Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Cheese obj = this.ReturnOne(id);
            this.Context.Set<Cheese>().Remove(obj);
            this.Context.SaveChanges();
        }

        public override void Insert(Cheese entity)
        {
            this.Context.Set<Cheese>().Add(entity);
            this.Context.SaveChanges();
        }

        public override Cheese ReturnOne(int id)
        {
            return this.ReturnAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
