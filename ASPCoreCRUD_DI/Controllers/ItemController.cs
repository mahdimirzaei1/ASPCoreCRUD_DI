using ASPCoreCRUD_DI.Entities.Models;
using ASPCoreCRUD_DI.Entities.Responses;
using ASPCoreCRUD_DI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreCRUD_DI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItem _items;

        public ItemController(IItem items)
        {
            _items = items;
        }

        // GET: api/item
        [HttpGet]
        [AllowAnonymous]
        public async Task<CollectionResult<Item>> Get()
        {
            return new CollectionResult<Item> { Collection = await Task.FromResult(await _items.Get()) };
        }

        // GET: api/item/5
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var item = await Task.FromResult(await _items.Get(id));
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/item
        [HttpPost]
        public async Task<ActionResult<Item>> Post(Item model)
        {
            _items.Create(model);

            return Ok(await Task.FromResult(model));
        }

        // PUT: api/item/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> Put(int id, Item model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            try
            {
                _items.Update(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(await Task.FromResult(model));
        }

        // DELETE: api/item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            if (!ItemExists(id))
            {
                return NotFound();
            }

            try
            {
                var deletedItem = _items.Delete(id);
                return Ok(await Task.FromResult(deletedItem));
            }
            catch (ArgumentNullException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool ItemExists(int id)
        {
            return _items.CheckExists(id);
        }
    }
}