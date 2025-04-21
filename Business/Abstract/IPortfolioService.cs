using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService : IGenericService<Portfolio>
    {
        List<PortfolioListDto> GetPortfolioList();

        PortfolioListDto GetByIDDto(int id);


    }
}
