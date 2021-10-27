using Hb_Project.Application.Dto.Create_Update;
using Hb_Project.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hb_Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User_Dto_Cu dto)
        {
            if (_userService.Update(id, dto))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult PostUser(User_Dto_Cu dto)
        {
            int dto_id = _userService.Add(dto);
            if (dto_id != 0)
            {
                return CreatedAtAction("GetUser", new { id = dto_id }, dto);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("The user cannot be deleted because it was not found");
        }
    }
}
