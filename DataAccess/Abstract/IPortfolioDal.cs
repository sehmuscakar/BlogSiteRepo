using Core.DataAccess;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPortfolioDal : IEntityRepository<Portfolio>
    {
        List<PortfolioListDto> GetPortfolioList();

        PortfolioListDto GetByIDDto(int id);

    }
}
