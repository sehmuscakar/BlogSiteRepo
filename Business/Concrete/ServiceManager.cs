using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service t)
        {
           _serviceDal.Add(t);
        }

        public void Delete(Service t)
        {
            _serviceDal.Delete(t);
        }

        public Service GetByID(int id)
        {
            Expression<Func<Service, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _serviceDal.Get(filter);
        }

        public IList<Service> GetList()
        {
           return _serviceDal.GetActiveList();
        }

        public void Update(Service t)
        {
          _serviceDal.Update(t);    
        }
    }
}
