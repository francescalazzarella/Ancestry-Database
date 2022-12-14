using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Catalog2.Api.Repositories;
using Catalog2.Api.Entities;
using Catalog2.Api.Dtos;
using System.Threading.Tasks;

namespace Catalog2.Api.Controllers
{

    // GET /items/
    [ApiController]
    [Route ("items")]
    public class ItemsContoller : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsContoller(IItemsRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

             return item.AsDto();
        }

        
        //POST /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                DOB = itemDto.DOB,
                BirthPlace = itemDto.BirthPlace,
                BirthAnnotation = itemDto.BirthAnnotation,
                DeathDate = itemDto.DeathDate,
                DeathPlace = itemDto.DeathPlace,
                CauseOfDeath = itemDto.CauseOfDeath,
                DeathAnnotation = itemDto.DeathAnnotation,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }

        //PUT /items/
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with 
            {
                Name = itemDto.Name,
                DOB = itemDto.DOB,
                BirthPlace = itemDto.BirthPlace,
                BirthAnnotation = itemDto.BirthAnnotation,
                DeathDate = itemDto.DeathDate,
                DeathPlace = itemDto.DeathPlace,
                CauseOfDeath = itemDto.CauseOfDeath,
                DeathAnnotation = itemDto.DeathAnnotation,
            };

            await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        // DELETE /items
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

           await repository.DeleteItemAsync(id);
            return NoContent();
        }

     
    }

}