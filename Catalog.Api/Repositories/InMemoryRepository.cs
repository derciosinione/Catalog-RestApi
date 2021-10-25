using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
    public class InMemoryRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 900, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "iphone 6s", Price = 1000, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Mouse", Price = 500, CreatedDate = DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Item>> GetItems()
        { 
            return await Task.FromResult(_items);
        } 
            

        public async Task<Item> GetItem(Guid id)
        {
            var item = _items.Where(i => i.Id == id).SingleOrDefault();
            return await Task.FromResult<Item>(item);
        }

        public async Task CreateItem(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItem(Item item)
        {
            var itemIndex = _items.FindIndex(i => i.Id == item.Id);
            _items[itemIndex] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItem(Guid id)
        {
            var itemIndex = _items.FindIndex(i => i.Id == id);
            _items.RemoveAt(itemIndex);
            await Task.CompletedTask;
        }
    }
}