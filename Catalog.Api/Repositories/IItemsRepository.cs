using System;
using Catalog.Api.Models;

namespace Catalog.Api.Repositories
{
    public interface IItemsRepository
    {
        Item GetItems();
        Item GetItem(Guid id);
    }
}