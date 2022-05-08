using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Models;
using System;
using System.Linq;

namespace GJJP8B_HFT_2021221.Repository
{
    public class MilkRepository : Repository<Milk>, IRepository<Milk>
    {
        public MilkRepository(CheeseContext context) : base(context)
        {

        }

        public override Milk ReturnOne(int id)
        {
            return context.Milks.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Milk milk)
        {
            var old = ReturnOne(milk.Id);
            if (old == null)
            {
                throw new ArgumentException("Item doesn't exist");
            }
            foreach (var item in old.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    item.SetValue(old, item.GetValue(milk));
                }
            }
            context.SaveChanges();
        }
    }
}
