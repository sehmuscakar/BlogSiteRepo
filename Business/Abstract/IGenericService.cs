using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        IList<T> GetList();
        T GetByID(int id);
    }
}
