using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reframe.Dal.Dto;
using Reframe.Dal.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reframe.Dal.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly PlaceService _placeService;

        public PlaceController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddPlace place)
        {
            try
            {
                var result = await _placeService.AddPlace(place);
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Hiba történt: " + e.Message);
            }

        }
        [HttpGet("taken")]
        public async Task<ActionResult> Taken([FromQuery] string searchText)
        {
            try
            {
                var result = await _placeService.GetIsTakenAsync(searchText);
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Hiba történt: " + e.Message);
            }

        }
    }
}
