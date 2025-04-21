using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PortfolioCategoryManager : IPortfolioCategoryService
    {
        private readonly IPortfolioCategoryDal _portfolioCategoryDal;

        public PortfolioCategoryManager(IPortfolioCategoryDal portfolioCategoryDal)
        {
            _portfolioCategoryDal = portfolioCategoryDal;
        }

        public void Add(PortfolioCategory t)
        {
            _portfolioCategoryDal.Add(t);
        }

        public void Delete(PortfolioCategory t)
        {
            _portfolioCategoryDal.Delete(t);
        }

        public PortfolioCategory GetByID(int id)
        {
            Expression<Func<PortfolioCategory, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _portfolioCategoryDal.Get(filter);
        }

        public IList<PortfolioCategory> GetList()
        {
            return _portfolioCategoryDal.GetActiveList();
        }

        public void Update(PortfolioCategory t)
        {
            _portfolioCategoryDal.Update(t);
        }
    }
}
