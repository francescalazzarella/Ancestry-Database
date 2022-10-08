using System;
using Microsoft.AspNetCore.Mvc;
using Catalog2.Repositories;
using Catalog2.Entities;

namespace Catalog2.Controllers
{

    // GET /items/
    [ApiController]
    [Route ("items")]
    public class ItemsContoller : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsContoller()
        {
            repository = new InMemItemsRepository();
        }

        //GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult <Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

             return item;
        }
    }

}