using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfGenericRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity> where TContext :  DbContext, new() where TEntity : class ,IEntity,new()
    {   
    
        public void Add(TEntity Entity)
        {
            using TContext context = new ();
            var addedEntity= context.Entry(Entity);
            addedEntity.State= EntityState.Added;   
            context.SaveChanges();
        }

        public void Delete(TEntity Entity)
        {
            using TContext context = new();
            var removedEntity= context.Entry(Entity);
            removedEntity.State= EntityState.Deleted; 
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new();
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity Entity)
        {
            using TContext context = new();
            var UpdatedEntity= context.Entry(Entity);
            UpdatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
