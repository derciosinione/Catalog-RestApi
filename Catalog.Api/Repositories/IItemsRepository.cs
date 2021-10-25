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
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}