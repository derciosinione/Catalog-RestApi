using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(Guid id);
        Task CreateItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(Guid id);
    }
}