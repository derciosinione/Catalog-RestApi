using System;
using System.Collections.Generic;
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
        public IEnumerable<Item> GetItems()
        {
            return _itemsCollection.Find(new BsonDocument()).ToList();
        }

        public Item GetItem(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            return _itemsCollection.Find(filter).SingleOrDefault();
        } 

        public void CreateItem(Item item)
        {
            _itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            _itemsCollection.ReplaceOne(filter, item);
        }

        public void DeleteItem(Guid id)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, id);
            _itemsCollection.DeleteOne(filter);
        }
    }
}