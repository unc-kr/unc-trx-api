using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using TransitionRegistry.Models;

namespace TransitionRegistry.Repositories
{
    public abstract class BaseRepository<C, T>
        where T : BaseEntity
        where C : DbContext, new()
    {

        private C _entities = new C();
        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual T GetSingle(int id)
        {
            var entity = this.GetAll().FirstOrDefault(x => x.Id == id);
            this.UpdateLastAccessed(entity);
            return entity;
        }

        public bool Exists(int id)
        {
            return this.GetAll().Count(e => e.Id == id) > 0;
        }

        protected virtual void UpdateLastAccessed(T entity)
        {
            entity.LastAccessDate = DateTime.Now;
            this._Edit(entity);
            this.Save();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.LastModifiedDate = DateTime.Now;
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        protected virtual void _Edit(T entity) {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Edit(T entity)
        {
            this._Edit(entity);
            entity.LastModifiedDate = DateTime.Now;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}