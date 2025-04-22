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
    public class SkillDal : EfEntityRepositoryBase<Skill>, ISkillDal
    {
        private ProjeContext Context { get; }

        public SkillDal(ProjeContext context) : base(context)
        {
            Context = context;
        }
    }
}
