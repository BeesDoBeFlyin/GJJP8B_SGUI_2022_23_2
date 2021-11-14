﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GJJP8B_HFT_2021221.Models;

namespace GJJP8B_HFT_2021221.Repository
{
    public interface IMilkRepository : IRepository<Milk>
    {
        void ChangeName(int id, string newName);

        void ChangePrice(int id, int newPrice);
    }
}