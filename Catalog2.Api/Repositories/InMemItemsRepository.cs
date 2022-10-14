using System;
using System.Collections.Generic;
using Catalog2.Api.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Api.Repositories
{

    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {
                Id = Guid.NewGuid(), 
                Name = "Erminia Amelia Caira", 
                DOB = "24 Nov 1912", 
                BirthPlace = "Marano Principato",
                BirthAnnotation = "Unavailable",
                DeathDate = "23 Feb 1995",
                DeathPlace = "Marano Principato",
                CauseOfDeath = "Natural",
                DeathAnnotation = "Unavailable",
                CreatedDate = DateTimeOffset.UtcNow
                },
            new Item 
            {
                Id = Guid.NewGuid(), 
                Name = "Giulia Ruffolo", 
                DOB = "1 Jan 1916", 
                BirthPlace = "Marano Principato",
                BirthAnnotation = "Unavailable",
                DeathDate = "5 Feb 1947",
                DeathPlace = "Marano Principato",
                CauseOfDeath = "Brain Tumor",
                DeathAnnotation = "Unavailable",
                CreatedDate = DateTimeOffset.UtcNow
                },
            new Item 
                {
                Id = Guid.NewGuid(), 
                Name = "Francesca Bilotti", 
                DOB = "12 May 1905", 
                BirthPlace = "Marano Marchesato",
                BirthAnnotation = "Marano Marchesato 'Atti di Nascita 1905' Page 15, Listing 38",
                DeathDate = "20 Apr 1988",
                DeathPlace = "Kenosha, WI",
                CauseOfDeath = "Dementia",
                DeathAnnotation = "Kenosha News April 21, 1988, Page 4",
                CreatedDate = DateTimeOffset.UtcNow
                }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        
        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }

    }
}