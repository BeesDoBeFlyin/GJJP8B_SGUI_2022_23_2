using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Models;

namespace GJJP8B_HFT_2021221.Repository
{
    public class BuyerRepository : Repository<Buyer>, IRepository<Buyer>
    {
        public BuyerRepository(CheeseContext context) : base(context)
        {

        }

        public override Buyer ReturnOne(int id)
        {
            return context.Buyers.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Buyer buyer)
        {
            var old = ReturnOne(buyer.Id);
            if (old == null)
            {
                throw new ArgumentException("Item doesn't exist");
            }
            foreach (var item in old.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    item.SetValue(old, item.GetValue(buyer));
                }
            }
            context.SaveChanges();
        }
    }
}
