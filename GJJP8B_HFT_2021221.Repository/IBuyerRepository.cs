using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Repository
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        void ChangeName(int id, string newName);

        void ChangeMoney(int id, int newMoney);

        void ChangePreferredCheese(int id, int newCheeseId);
    }
}
