using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.DAL.Reposatories.Generic_Reposatory
{
    public interface IGenericRepo<TEntity>
    {
        public IQueryable<TEntity> GetAll(bool withTracking = false);
        public TEntity GetById(int id);
        public void Add(TEntity item);
        public void Update(TEntity item);
        public void Delete(int id);

        public void Detach(TEntity entity);

    }
}
