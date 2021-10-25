using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
    public class InMemoryRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems()
        { 
            return _items;
        } 
            

        public Item GetItem(Guid id)
        { 
            return _items.Where(i => i.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var itemIndex = _items.FindIndex(i => i.Id == item.Id);
            _items[itemIndex] = item;
        }
    }
}