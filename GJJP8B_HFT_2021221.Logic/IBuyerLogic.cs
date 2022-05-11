using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public interface IBuyerLogic
    {
        void Create(Buyer buyer);
        void Delete(int id);
        Buyer GetOne(int id);
        IQueryable<Buyer> GetAll();
        void Update(Buyer buyer);

        IEnumerable<Buyer> ListBuyersWithCheese();
    }
}
