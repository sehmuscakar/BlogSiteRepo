using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfolioDal : EfEntityRepositoryBase<Portfolio, ProjeContext>, IPortfolioDal
    {
        public PortfolioListDto GetByIDDto(int id)
        {
            using (var context = new ProjeContext())
            {
                return context.Portfolios
                    .Include(p => p.PortfolioCategory)
                    .Where(p => p.Id == id)
                    .Select(p => new PortfolioListDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        Image1 = p.Image1,
                        Image2 = p.Image2,
                        Image3 = p.Image3,
                        PortfolioCategoryName = p.PortfolioCategory.Name
                    })
                    .SingleOrDefault();
            }
        }


        public List<PortfolioListDto> GetPortfolioList()
        {
            using (var context = new ProjeContext())
            {
                var a = context.Portfolios.Select(portfolio => new PortfolioListDto()
                {
                    Id = portfolio.Id,
                    Title = portfolio.Title,
                    Image1 = portfolio.Image1,
                    Image2 = portfolio.Image2,
                    Image3 = portfolio.Image3,
                 
                    Description = portfolio.Description,
                    PortfolioCategoryName = portfolio.PortfolioCategory.Name,
                ProjectUrl= portfolio.ProjectUrl,

                });
                return a.ToList();
            }

        }
    }
}
