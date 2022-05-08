using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Data;

namespace GJJP8B_HFT_2021221.Repository
{
    public class CheeseRepository : Repository<Cheese>, IRepository<Cheese>
    {
        public CheeseRepository(CheeseContext context) : base(context)
        {

        }

        public override Cheese ReturnOne(int id)
        {
            return context.Cheeses.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Cheese cheese)
        {
            var old = ReturnOne(cheese.Id);
            if (old == null)
            {
                throw new ArgumentException("Item doesn't exist");
            }
            foreach (var item in old.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    item.SetValue(old, item.GetValue(cheese));
                }
            }
            context.SaveChanges();
        }
    }
}
