using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public interface IMilkLogic
    {
        int MilkCount { get; }
        List<Milk> GetAll();
        void AddMilk(Milk mk);
        Milk GetMilkByIndex(int index);
    }
}
