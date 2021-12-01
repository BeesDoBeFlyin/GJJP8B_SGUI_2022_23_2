﻿using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Logic
{
    public interface IBuyerLogic
    {
        IQueryable<Buyer> GetAll();
        void AddBuyer(Buyer buy);
        void ChangeBuyerName(int id, string newName);
        Buyer GetBuyerById(int id);
        void DeleteBuyerById(int id);
        void ChangeMoney(int id, int newMoney);
        void ChangePreferredCheese(int id, int newCheeseId);
    }
}
