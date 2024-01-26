using System.ComponentModel.DataAnnotations;
using BBP.Model;

namespace BBP.Dto
{
    public class StockForDisplayDto
    {
        public int BeerId { get; set; }
        public int WholesalerId { get; set; }

        public int Quantity { get; set; }

        public virtual BeerForDisplayDto? Beer { get; set; }
        public virtual WholesalerForDisplayDto? Wholesaler { get; set; }

        static public StockForDisplayDto FromStock(Stock stock, bool proliferateBeer = true, bool proliferateWholesaler = true)
        {
            StockForDisplayDto dto = new StockForDisplayDto
            {
                BeerId = stock.BeerId,
                WholesalerId = stock.WholesalerId,
                Quantity = stock.Quantity,
                Beer = proliferateBeer == true && stock.Beer != null ? BeerForDisplayDto.FromBeer(stock.Beer, null, false): null,
                Wholesaler = proliferateWholesaler == true && stock.Wholesaler != null ? WholesalerForDisplayDto.FromWholesaler(stock.Wholesaler, false): null,
            };
            return dto;
        }

    }
    
}