using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.API.DataAccess.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task AddBulk(List<TEntity> entity, string partitionKey);
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id, string partitionKey);
        Task DeleteBulk(Guid id, string partitionKey);
    }
}
