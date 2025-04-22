using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfolioCategoryDal : EfEntityRepositoryBase<PortfolioCategory>, IPortfolioCategoryDal
    {
        private ProjeContext Context { get; }

        public PortfolioCategoryDal(ProjeContext context) : base(context)
        {
            Context = context;
        }

      

      
    }
}
