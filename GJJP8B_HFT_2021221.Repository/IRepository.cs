using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Repository
{
    interface IRepository<T> where T : class
    {
        T ReturnOne(int id);

        IQueryable<T> ReturnAll();

        void Insert(T entity);

        void Delete(int id);
    }
}
