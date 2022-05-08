using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T ReturnOne(int id);

        IQueryable<T> ReturnAll();

        void Create(T entity);
        void Update(T entity);

        void Delete(int id);
    }
}
