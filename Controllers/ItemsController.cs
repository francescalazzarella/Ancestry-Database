using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Catalog2.Repositories;
using Catalog2.Entities;
using Catalog2.Dtos;

namespace Catalog2.Controllers
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
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

             return item.AsDto();
        }
    }

}