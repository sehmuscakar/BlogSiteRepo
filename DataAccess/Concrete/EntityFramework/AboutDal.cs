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
    public class AboutDal : EfEntityRepositoryBase<About>, IAboutDal
    {
        private ProjeContext Context { get; }

        public AboutDal(ProjeContext context) : base(context)
        {
            Context = context;
        }

    }
}
