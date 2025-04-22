using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ResumeDal : EfEntityRepositoryBase<Resume>, IResumeDal
    {
        private ProjeContext Context { get; }

        public ResumeDal(ProjeContext context) : base(context)
        {
            Context = context;
        }
    }
}
