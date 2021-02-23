using Example.API.DataAccess.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.API.DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly Container _container;
        private IConfiguration _configuration;

        public RepositoryBase(Container container,
                              IConfiguration configuration)
        {
            _container = container;
            _configuration = configuration;
        }

        //get all entities
        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                var entities = new List<TEntity>();
                var queryStatement = $"SELECT * FROM {typeof(TEntity).Name} p ";
                var query = new QueryDefinition(queryStatement);
                var queryIterator = _container.GetItemQueryIterator<TEntity>(query);
                while (queryIterator.HasMoreResults)
                {
                    var entityResponse = await queryIterator.ReadNextAsync();
                    var iterations = entityResponse.Resource;
                    entities.AddRange(iterations);
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        

        //update entity
        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                var entityToUpdate = await _container.UpsertItemAsync(entity);

                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        //delete entity
        public async Task Delete(Guid id, string partitionKey)
        {
            if (partitionKey == string.Empty)
                partitionKey = id.ToString();
            try
            {
                await _container.DeleteItemAsync<TEntity>(id.ToString(), new PartitionKey(partitionKey));
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        //add new entity
        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                var entityToAdd = await _container.CreateItemAsync(entity);

                return entityToAdd;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        //add entities bulk
        public async Task AddBulk(List<TEntity> entities, string partitionKey)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                List<Task> concurrentTasks = new List<Task>();

                foreach (var entity in entities)
                {
                    concurrentTasks.Add(_container.CreateItemAsync<TEntity>(entity));
                }

                await Task.WhenAll(concurrentTasks);

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved: {ex.Message}");
            }
        }

        //delete entity bulk
        public async Task DeleteBulk(Guid id, string partitionKey)
        {

            try
            {
                if (partitionKey == string.Empty)
                    partitionKey = id.ToString();

                List<Task> concurrentTasks = new List<Task>();
                var entities = await GetAll();

                foreach (var entity in entities)
                {
                    concurrentTasks.Add(_container.DeleteItemAsync<TEntity>(id.ToString(), new PartitionKey(partitionKey)));
                }

                await Task.WhenAll(concurrentTasks);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
    }
}
