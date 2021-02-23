using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example.API.DataAccess.Containers
{
    public class AccountContainer : Container
    {
        private Container _container;
        public AccountContainer(Container container)
        {
            _container = container;
        }
        public override string Id => _container.Id;

        public override Database Database => _container.Database;

        public override Conflicts Conflicts => _container.Conflicts;

        public override Scripts Scripts => _container.Scripts;

        public override Task<ItemResponse<T>> CreateItemAsync<T>(T item, PartitionKey? partitionKey = null, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.CreateItemAsync(item, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.CreateItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);
        }

        public override TransactionalBatch CreateTransactionalBatch(PartitionKey partitionKey)
        {
            return _container.CreateTransactionalBatch(partitionKey);
        }

        public override Task<ContainerResponse> DeleteContainerAsync(ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.DeleteContainerAsync(requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> DeleteContainerStreamAsync(ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.DeleteContainerStreamAsync(requestOptions, cancellationToken);
        }

        public override Task<ItemResponse<T>> DeleteItemAsync<T>(string id, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.DeleteItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> DeleteItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.DeleteItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);
        }

        public override ChangeFeedProcessorBuilder GetChangeFeedEstimatorBuilder(string processorName, ChangesEstimationHandler estimationDelegate, TimeSpan? estimationPeriod = null)
        {
            return _container.GetChangeFeedEstimatorBuilder(processorName, estimationDelegate, estimationPeriod);
        }

        public override ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder<T>(string processorName, ChangesHandler<T> onChangesDelegate)
        {
            return _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);
        }

        public override IOrderedQueryable<T> GetItemLinqQueryable<T>(bool allowSynchronousQueryExecution = false, string continuationToken = null, QueryRequestOptions requestOptions = null)
        {
            return _container.GetItemLinqQueryable<T>(allowSynchronousQueryExecution, continuationToken, requestOptions);
        }

        public override FeedIterator<T> GetItemQueryIterator<T>(QueryDefinition queryDefinition, string continuationToken = null, QueryRequestOptions requestOptions = null)
        {
            return _container.GetItemQueryIterator<T>(queryDefinition, continuationToken, requestOptions);
        }

        public override FeedIterator<T> GetItemQueryIterator<T>(string queryText = null, string continuationToken = null, QueryRequestOptions requestOptions = null)
        {
            return _container.GetItemQueryIterator<T>(queryText, continuationToken, requestOptions);
        }

        public override FeedIterator GetItemQueryStreamIterator(QueryDefinition queryDefinition, string continuationToken = null, QueryRequestOptions requestOptions = null)
        {
            return _container.GetItemQueryStreamIterator(queryDefinition, continuationToken, requestOptions);
        }

        public override FeedIterator GetItemQueryStreamIterator(string queryText = null, string continuationToken = null, QueryRequestOptions requestOptions = null)
        {
            return _container.GetItemQueryStreamIterator(queryText, continuationToken, requestOptions);
        }

        public override Task<ContainerResponse> ReadContainerAsync(ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReadContainerAsync(requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> ReadContainerStreamAsync(ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReadContainerStreamAsync(requestOptions, cancellationToken);
        }

        public override Task<ItemResponse<T>> ReadItemAsync<T>(string id, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReadItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> ReadItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReadItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<int?> ReadThroughputAsync(CancellationToken cancellationToken = default)
        {
            return _container.ReadThroughputAsync(cancellationToken);
        }

        public override Task<ThroughputResponse> ReadThroughputAsync(RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return _container.ReadThroughputAsync(requestOptions, cancellationToken);
        }

        public override Task<ContainerResponse> ReplaceContainerAsync(ContainerProperties containerProperties, ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceContainerAsync(containerProperties, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> ReplaceContainerStreamAsync(ContainerProperties containerProperties, ContainerRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceContainerStreamAsync(containerProperties, requestOptions, cancellationToken);
        }

        public override Task<ItemResponse<T>> ReplaceItemAsync<T>(T item, string id, PartitionKey? partitionKey = null, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceItemAsync(item, id, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> ReplaceItemStreamAsync(Stream streamPayload, string id, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceItemStreamAsync(streamPayload, id, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ThroughputResponse> ReplaceThroughputAsync(int throughput, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceThroughputAsync(throughput, requestOptions, cancellationToken);
        }

        public override Task<ThroughputResponse> ReplaceThroughputAsync(ThroughputProperties throughputProperties, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.ReplaceThroughputAsync(throughputProperties, requestOptions, cancellationToken);
        }

        public override Task<ItemResponse<T>> UpsertItemAsync<T>(T item, PartitionKey? partitionKey = null, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.UpsertItemAsync(item, partitionKey, requestOptions, cancellationToken);
        }

        public override Task<ResponseMessage> UpsertItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return _container.UpsertItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);
        }
    }
}
