using System;
using System.Collections.Generic;
using Catalog2.Api.Entities;
using System.Threading.Tasks;

namespace Catalog2.Api.Repositories
{
     public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync (Item item);
        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);

    }
}