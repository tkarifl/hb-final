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
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemController : ControllerBase
    {
        private readonly IListItemService _listItemService;

        public ListItemController(IListItemService listItemService)
        {
            _listItemService = listItemService;
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            return Ok(_listItemService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetListItem(int id)
        {
            var listItem = _listItemService.Get(id);
            if (listItem == null)
            {
                return NotFound();
            }

            return Ok(listItem);
        }

        [HttpPut("{id}")]
        public IActionResult PutListItem(int id, ListItem_Dto_Cu dto)
        {
            if (_listItemService.Update(id, dto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostListItem(ListItem_Dto_Cu dto)
        {
            int dto_id = _listItemService.Add(dto);
            if (dto_id != 0)
            {
                return CreatedAtAction("GetListItem", new { id = dto_id }, dto);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteListItem(int id)
        {
            if (_listItemService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
