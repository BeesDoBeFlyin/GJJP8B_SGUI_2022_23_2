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
        int BuyerCount { get; }
        List<Buyer> GetAll();
        void AddBuyer(Buyer buy);
        Buyer GetBuyerByIndex(int index);
        void ChangeBuyerName(int id, string newName);
    }
}
