using Common.DataAccess;
using Domain;

namespace DataAccess
{
    public class RepositoryBase
    {
        public RepositoryBase(IUnitOfWorkFactory unitOfWorkFactory)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
        }

        public IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }

        public void Save(Entity entity)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                if (entity != null)
                {
                    unitOfWork.Session.SaveOrUpdate(entity);    
                }
                
                unitOfWork.Commit();
            }
        }
    }
}