using BBP.Dto;
using BBP.Model;
using BBP.Service;
using Microsoft.AspNetCore.Mvc;

namespace BBP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeerService BeerService;

        public BeersController(BeerService beerService)
        {
            this.BeerService = beerService;
        }

        [HttpGet("beers")]
        public async Task<ActionResult<IEnumerable<BeerForDisplayDto>>> GetBeers()
        {
            IEnumerable<Beer> beers = await this.BeerService.GetBeers();
            
            return Ok(beers.Select(b => BeerForDisplayDto.FromBeer(b)));
        }

        [HttpGet("beer/{id}")]
        public async Task<ActionResult<BeerForDisplayDto>> GetBeer(int id)
        {
            try
            {
                Beer beer = await this.BeerService.GetBeer(id);
                return Ok(BeerForDisplayDto.FromBeer(beer));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("beer")]
        public async Task<ActionResult<BeerForDisplayDto>> CreateBeer([FromBody] BeerForCreationDto beerDto)
        {
            try
            {
                Beer beer = await this.BeerService.CreateBeer(beerDto);
                return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, BeerForDisplayDto.FromBeer(beer));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("beer/{id}")]
        public async Task<ActionResult> DeleteBeer(int id)
        {
            try
            {
                await this.BeerService.DeleteBeer(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}