using System.ComponentModel.DataAnnotations;
using BBP.Model;

namespace BBP.Dto
{
    public class WholesalerForDisplayDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual IEnumerable<StockForDisplayDto>? Stocks { get; set; }

        static public WholesalerForDisplayDto FromWholesaler(Wholesaler wholesaler, bool proliferate = true)
        {
            WholesalerForDisplayDto dto = new WholesalerForDisplayDto
            {
                Id = wholesaler.Id,
                Name = wholesaler.Name,
                Stocks = proliferate == true ? wholesaler.Stocks?.Select(s => StockForDisplayDto.FromStock(s, true, false)) : null
            };
            return dto;
        }

    }
    
}