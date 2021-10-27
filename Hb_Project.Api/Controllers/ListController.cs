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
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        public ListController(IListService listService)
        {
            _listService = listService;
        }

        [HttpGet]
        public IActionResult GetLists()
        {
            return Ok(_listService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetList(int id)
        {
            var List = _listService.Get(id);
            if (List == null)
            {
                return NotFound();
            }

            return Ok(List);
        }

        [HttpPut("{id}")]
        public IActionResult PutList(int id, List_Dto_Cu dto)
        {
            if (_listService.Update(id, dto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult PostList(List_Dto_Cu dto)
        {
            int dto_id = _listService.Add(dto);
            if (dto_id != 0)
            {
                return CreatedAtAction("GetList", new { id = dto_id }, dto);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteList(int id)
        {
            if (_listService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
