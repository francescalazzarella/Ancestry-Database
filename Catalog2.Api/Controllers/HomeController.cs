using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Catalog2.Api.Repositories;
using Catalog2.Api.Entities;
using Catalog2.Api.Dtos;
using System.Threading.Tasks;

namespace Catalog2.Api.Controllers
{
    [ApiController]
    [Route ("home")]
    public class HomeContoller : ControllerBase
    {
        private readonly IItemsRepository repository;

        public HomeContoller(IItemsRepository repository)
        {
            this.repository = repository;
        }

    }
}