using Final_Api_Project.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        protected readonly E_CommerceContext _context;

        public GenericRepository(E_CommerceContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
               // .AsNoTracking();
        }

        public TEntity? Find(object id)
        {
            return _context.Set<TEntity>()
                .Find(id);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>()
                .Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>()
                .Remove(entity);
        }
        public void Delete(object id) {
            TEntity entity = _context.Set<TEntity>().Find(id);
            if(entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}