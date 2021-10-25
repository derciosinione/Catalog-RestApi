using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class MongoDbItemRepository : IItemsRepository
    {
        private readonly IMongoCollection<Item> _itemsCollection;
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;


        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase("CatalogDb");
            _itemsCollection = database.GetCollection<Item>("items");
        }
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Item> GetItem(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            return await _itemsCollection.Find(filter).SingleOrDefaultAsync();
        } 

        public async void CreateItem(Item item)
        {
            await _itemsCollection.InsertOneAsync(item);
        }

        public async void UpdateItem(Item item)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await _itemsCollection.ReplaceOneAsync(filter, item);
        }

        public async void DeleteItem(Guid id)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, id);
            await _itemsCollection.DeleteOneAsync(filter);
        }
    }
}