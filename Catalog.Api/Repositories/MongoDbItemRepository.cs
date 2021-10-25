using System;
using System.Collections.Generic;
using Catalog.Api.Models;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class MongoDbItemRepository : IItemsRepository
    {
        private readonly IMongoCollection<Item> _itemsCollection;
        private const string _databaseName = "CatalogDb";
        private const string _collectionName = "items";
        

        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(_databaseName);
            _itemsCollection = database.GetCollection<Item>(_collectionName);
        }
        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        } 

        public void CreateItem(Item item)
        {
            _itemsCollection.InsertOne(item);
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}