using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Points_Of_Interest.Api.Dtos;
using Points_Of_Interest.Api.Services;

namespace Points_Of_Interest.Api.Controllers
{
    [ApiController]
    [Route("api/points-of-interest")]
    public class POIController : ControllerBase
    {
        private readonly POIServices _poiServices;

        public POIController(POIServices poiServices)
        {
            _poiServices = poiServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _poiServices.ListAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePOIDto createPOIDto)
        {
            try
            {
                await _poiServices.CreatePOI(createPOIDto);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("closer")]
        public async Task<IActionResult> GetCloserPOI([FromBody] GetCloserPOIDto closerPOIDto)
        {
            var result = await _poiServices.GetClosests(closerPOIDto);

            return Ok(result);
        }
    }
}