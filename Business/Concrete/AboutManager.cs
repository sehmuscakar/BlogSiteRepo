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
    public class AboutManager : IAboutService
    {

        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About t)
        {
            _aboutDal.Add(t);
        }

        public void Delete(About t)
        {
          _aboutDal.Delete(t);
        }

        public About GetByID(int id)
        {
            Expression<Func<About, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _aboutDal.Get(filter);
        }

        public IList<About> GetList()
        {
            return _aboutDal.GetActiveList();
        }

        public void Update(About t)
        {
         _aboutDal.Update(t);       
        }
    }
}
