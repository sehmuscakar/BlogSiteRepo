using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {

        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }
        public void Add(Skill t)
        {
           _skillDal.Add(t);
        }

        public void Delete(Skill t)
        {
         _skillDal.Delete(t);
        }

        public Skill GetByID(int id)
        {
            Expression<Func<Skill, bool>> filter = x => x.Id == id;  // bunun dataAccess te olması lazım 
            return _skillDal.Get(filter);
        }

        public IList<Skill> GetList()
        {
           return _skillDal.GetActiveList();
        }

        public void Update(Skill t)
        {
          _skillDal.Update(t);
        }
    }
}
