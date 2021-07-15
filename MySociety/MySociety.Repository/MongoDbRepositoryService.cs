using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MySociety.Entities;
using MySociety.Utilities;

namespace MySociety.Repository
{
    public class MongoDbRepositoryService : IRepositoryService
    {
        private readonly IDocumentClient _dataBaseContext;
        private readonly DatabaseConfiguration _databaseConfiguration;

        public MongoDbRepositoryService(IDocumentClient dataBaseContext, DatabaseConfiguration databaseConfiguration)
        {
            this._dataBaseContext = dataBaseContext;
            this._databaseConfiguration = databaseConfiguration;
        }

        public async Task<string> DeleteAsync<TEntity>(string id) where TEntity : BaseEntity
        {
            Uri collectionUri = UriFactory.CreateDocumentUri(this._databaseConfiguration.Name, typeof(TEntity).Name, id);

            ResourceResponse<Document> document = await this._dataBaseContext.DeleteDocumentAsync(collectionUri);

            return document.Resource.Id;
        }

        public IEnumerable<TEntity> GetByFilterAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : BaseEntity
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(this._databaseConfiguration.Name, typeof(TEntity).Name);

            IOrderedQueryable<TEntity> query = this._dataBaseContext.CreateDocumentQuery<TEntity>(collectionUri, new FeedOptions { EnableCrossPartitionQuery = true });

            return filter != null ? query.Where(filter) : query;
        }

        public async Task<TEntity> GetAsync<TEntity>(string id) where TEntity : BaseEntity
        {
            Uri collectionUri = UriFactory.CreateDocumentUri(this._databaseConfiguration.Name, typeof(TEntity).Name, id);

            return await this._dataBaseContext.ReadDocumentAsync<TEntity>(collectionUri, new RequestOptions() { PartitionKey = new PartitionKey(id) });
        }

        public async Task<string> InsertAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(this._databaseConfiguration.Name, typeof(TEntity).Name);

            ResourceResponse<Document> document = await this._dataBaseContext.UpsertDocumentAsync(collectionUri, entity);

            return document.Resource.Id;
        }

        public async Task<string> UpdateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Uri collectionUri = UriFactory.CreateDocumentCollectionUri(this._databaseConfiguration.Name, typeof(TEntity).Name);

            ResourceResponse<Document> document = await this._dataBaseContext.UpsertDocumentAsync(collectionUri, entity);

            return document.Resource.Id;
        }
    }
}
