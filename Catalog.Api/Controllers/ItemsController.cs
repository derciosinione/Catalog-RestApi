using System;
using System.Collections.Generic;
using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemoryRepository _repository = new InMemoryRepository();

        // public ItemsController(InMemoryRepository repository)
        // {
        //     _repository = repository;
        // }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _repository.GetItems();
            return items;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
            {
                NotFound();
            }
            
            return Ok(item);
        }
    }
}