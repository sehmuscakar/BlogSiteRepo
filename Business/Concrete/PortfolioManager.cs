using Business.Abstract;
using DataAccess.Abstract;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void Add(Portfolio t)
        {
          _portfolioDal.Add(t);
        }

        public void Delete(Portfolio t)
        {
          _portfolioDal.Delete(t);
        }

        public Portfolio GetByID(int id)
        {
            Expression<Func<Portfolio, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _portfolioDal.Get(filter);
        }

        public PortfolioListDto GetByIDDto(int id)
        {
           return _portfolioDal.GetByIDDto(id);
        }

        public IList<Portfolio> GetList()
        {
           return _portfolioDal.GetActiveList();
        }

        public List<PortfolioListDto> GetPortfolioList()
        {
            return _portfolioDal.GetPortfolioList();
        }

        public void Update(Portfolio t)
        {
           _portfolioDal.Update(t);
        }
    }
}
