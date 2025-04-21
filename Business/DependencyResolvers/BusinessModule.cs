using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class BusinessModule
    {
        public static void MyconfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, AboutDal>();

            services.AddScoped<IResumeService, ResumeManager>();
            services.AddScoped<IResumeDal, ResumeDal>();

            services.AddScoped<IPortfolioService, PortfolioManager>();
            services.AddScoped<IPortfolioDal, PortfolioDal>();

            services.AddScoped<IPortfolioCategoryService, PortfolioCategoryManager>();
            services.AddScoped<IPortfolioCategoryDal, PortfolioCategoryDal>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, ServiceDal>();

            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISkillDal, SkillDal>();

        }
    }
}
