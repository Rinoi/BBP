using BBP.Dto;
using BBP.Model;
using BBP.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BBP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BrewerysController : ControllerBase
    {
        private readonly BreweryService BreweryService;

        public BrewerysController(BreweryService breweryService)
        {
            this.BreweryService = breweryService;
        }

        [HttpGet("brewerys")]
        public async Task<ActionResult<IEnumerable<BreweryForDisplayDto>>> GetBrewerys()
        {
            IEnumerable<Brewery> brewerys = await this.BreweryService.GetBrewerys();
            IEnumerable<BreweryForDisplayDto> brewerysDto = brewerys.Select(b => BreweryForDisplayDto.FromBrewery(b));

            return Ok(brewerysDto);
        }

        [HttpGet("brewery/{id}")]
        public async Task<ActionResult<BreweryForDisplayDto>> GetBrewery(int id)
        {
            try
            {
                Brewery brewery = await this.BreweryService.GetBrewery(id);
                return Ok(BreweryForDisplayDto.FromBrewery(brewery));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("brewery")]
        public async Task<ActionResult<BreweryForDisplayDto>> CreateBrewery([FromBody] BreweryForCreationDTO breweryDto)
        {
            Brewery brewery = await this.BreweryService.CreateBrewery(breweryDto);
            return CreatedAtAction(nameof(GetBrewery), new { id = brewery.Id }, BreweryForDisplayDto.FromBrewery(brewery));
        }


        [HttpGet("brewerys/stock")]
        public async Task<ActionResult<IEnumerable<Brewery>>> GetBrewerysStock()
        {
            IEnumerable<BreweryForDisplayDto> brewerysDto = await this.BreweryService.GetBrewerysStock();
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Ok(JsonSerializer.Serialize(brewerysDto, jsonOptions));
        }
    }
}
