using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hb_Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_itemService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _itemService.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item_Dto_Cu dto)
        {
            if (_itemService.Update(id, dto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostItem(Item_Dto_Cu dto)
        {
            int dto_id = _itemService.Add(dto);
            if (dto_id != 0)
            {
                return CreatedAtAction("GetItem", new { id = dto_id }, dto);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_itemService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
