using Common.DataAccess;
using Domain;

namespace DataAccess
{
    public class RepositoryBase
    {
        public RepositoryBase(ISimpleUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

		public ISimpleUnitOfWork UnitOfWork { get; private set; }

        public void Save(Entity entity)
        {
            if (entity != null)
            {
				UnitOfWork.Session.SaveOrUpdate(entity);    
            }
        }
    }
}