using BBP.Model;

namespace BBP.Dto
{
    public class BeerForDisplayDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }        
        public double AlcoholPercentage { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }

        public BreweryForDisplayDto? Brewery { get; set; }
        public IEnumerable<StockForDisplayDto>?  Stocks { get; set; }

        static public BeerForDisplayDto FromBeer(Beer beer, IEnumerable<StockForDisplayDto>? stocks = null, bool proliferate = true)
        {
            BeerForDisplayDto dto = new BeerForDisplayDto
            {
                Id = beer.Id,
                Name = beer.Name,
                AlcoholPercentage = beer.AlcoholPercentage,
                Price = beer.Price,
                BreweryId = beer.BreweryId,
                Brewery = proliferate == true && beer.Brewery != null ? BreweryForDisplayDto.FromBrewery(beer.Brewery, false): null,
                Stocks = stocks
            };
            return dto;
        }
    }
}