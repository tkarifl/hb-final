using Hb_Project.Application.IServices;
using Hb_Project.Application.Services;
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
    public class ReportController : ControllerBase
    {
        private readonly IMongoService _mongoService;

        public ReportController(IMongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet("api/[controller]/general-favourites")]
        public IActionResult GetGeneralFavouriteItems()
        {
            return Ok(_mongoService.GetGeneralFavouriteItems());
        }
        [HttpGet("api/[controller]/user-favourites/{id}")]
        public IActionResult GetUserFavouriteItems(int id)
        {
            return Ok(_mongoService.GetUserFavouriteItems(id));
        }
    }
}
