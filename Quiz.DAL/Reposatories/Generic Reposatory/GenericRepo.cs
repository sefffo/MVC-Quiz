using Quiz.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Quiz.DAL.Reposatories.Generic_Reposatory
{
    public class GenericRepo<TEntity>:IGenericRepo<TEntity> where TEntity: class
    {
        private readonly QuizDbContext _context;

        public GenericRepo(QuizDbContext context) 
        {
            this._context = context;
        }

        public IQueryable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking == true)
            {
                return _context.Set<TEntity>();
            }
            else
            {
                return _context.Set<TEntity>().AsNoTracking();
            }
        }

        public TEntity GetById(int id)
        {
            var item = _context.Set<TEntity>().Find(id);
            return item;
        }
        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
            //return _context.SaveChanges();//return number of affected rows


        }

        public void Update(TEntity item)
        {
            _context.Set<TEntity>().Update(item);
            //return _context.SaveChanges();//return number of affected rows
        }

        public void Delete(int id)
        {
            _context.Set<TEntity>().Remove(GetById(id));
            //return _context.SaveChanges();//return number of affected rows
        }
        public void Detach(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }


    }
}
