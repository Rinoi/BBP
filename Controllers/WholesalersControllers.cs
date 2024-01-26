using BBP.Dto;
using BBP.Model;
using BBP.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BBP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly WholesalerService WholesalerService;
        private readonly StockService StockService;

        public WholesalersController(WholesalerService wholesalerService, StockService stockService)
        {
            this.WholesalerService = wholesalerService;
            this.StockService = stockService;
        }

        [HttpGet("wholesalers")]
        public async Task<ActionResult<IEnumerable<WholesalerForDisplayDto>>> GetWholesalers()
        {
            IEnumerable<Wholesaler> wholesalers = await this.WholesalerService.GetWholesalers();
            IEnumerable<WholesalerForDisplayDto> wholesalersDtos = wholesalers.Select(w => WholesalerForDisplayDto.FromWholesaler(w));

            return Ok(wholesalersDtos);
        }

        [HttpGet("wholesaler/{id}")]
        public async Task<ActionResult<WholesalerForDisplayDto>> GetWholesaler(int id)
        {
            try
            {
                Wholesaler wholesaler = await this.WholesalerService.GetWholesaler(id);

                return Ok(WholesalerForDisplayDto.FromWholesaler(wholesaler));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPut("wholesaler/{id}/stock")]
        public async Task<ActionResult<StockForDisplayDto>> UpdateWholesalerStock(int id, [FromBody] StockForUpdateDto stockDto)
        {
            try
            {
                Stock stock = await this.StockService.UpdateStock(id, stockDto.BeerId, stockDto.Quantity); 

                return Ok(StockForDisplayDto.FromStock(stock));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("wholesaler")]
        public async Task<ActionResult<WholesalerForDisplayDto>> CreateWholesaler([FromBody] WholesalerForCreationDTO wholesalerDto)
        {
            Wholesaler newWholesaler = await this.WholesalerService.CreateWholesaler(wholesalerDto);

            return CreatedAtAction(nameof(GetWholesaler), new { id = newWholesaler.Id }, WholesalerForDisplayDto.FromWholesaler(newWholesaler));
        }


        [HttpGet("wholesaler/{id}/devis")]
        public async Task<ActionResult<WholesalerForDisplayDto>> GetWholesalerDevis(int id, [FromBody] WholesalerDevisForCreationDTO devisDto)
        {
            devisDto.Id = id;
            try
            {
                WholesalerDevisForResponseDTO devis = await this.WholesalerService.GetWholesalerDevis(devisDto); 

                return Ok(devis);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
