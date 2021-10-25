using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
    public class InMemoryRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "HP Computer", Price = 100, CreatedDate = DateTimeOffset.UtcNow}
        };

        public IEnumerable<Item> GetItems() => _items;

        public Item GetItem(Guid id) => _items.Where(i => i.Id == id).SingleOrDefault();
    }
}