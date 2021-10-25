using System;
using System.Collections.Generic;
using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemoryRepository _repository;

        public ItemsController(InMemoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _repository.GetItems();
        }
        
        [HttpGet("{id}")]
        public Item GetItem(Guid id)
        {
            return _repository.GetItem(id);
        }
    }
}