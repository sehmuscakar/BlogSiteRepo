using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ResumeManager : IResumeService
    {

        private readonly IResumeDal _resumeDal;

        public ResumeManager(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }

        public void Add(Resume t)
        {
            _resumeDal.Add(t);
        }

        public void Delete(Resume t)
        {
          _resumeDal.Delete(t);
        }

        public Resume GetByID(int id)
        {
            Expression<Func<Resume, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _resumeDal.Get(filter);
        }

        public IList<Resume> GetList()
        {
            return _resumeDal.GetActiveList();
        }

        public void Update(Resume t)
        {
          _resumeDal.Update(t);
        }
    }
}
