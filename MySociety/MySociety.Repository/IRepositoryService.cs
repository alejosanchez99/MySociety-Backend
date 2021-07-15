using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MySociety.Entities;

namespace MySociety.Repository
{
    public interface IRepositoryService
    {
        public IEnumerable<TEntity> GetByFilterAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : BaseEntity;

        public Task<TEntity> GetAsync<TEntity>(string id) where TEntity : BaseEntity;

        public Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

        public Task<string> InsertAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

        public Task<string> DeleteAsync<TEntity>(string id) where TEntity : BaseEntity;
    }
}
