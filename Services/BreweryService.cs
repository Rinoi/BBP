using BBP;
using BBP.Dto;
using BBP.Model;
using Microsoft.EntityFrameworkCore;

namespace BBP.Service
{
    public class BreweryService
    {
        private readonly ApplicationDbContext Context;
        private readonly StockService StockService;

        public BreweryService(ApplicationDbContext context, StockService stockService)
        {
            this.Context = context;
            this.StockService = stockService;
        }

        public async Task<IEnumerable<Brewery>> GetBrewerys()
        {
            Console.WriteLine("TOTO");
            IEnumerable<Brewery> brewerys = await Context.Brewerys
                                                .Include(b => b.Beers)
                                                .ToListAsync();
            
            return brewerys;
        }

        public async Task<Brewery> GetBrewery(int id)
        {
            Brewery? brewery = await Context.Brewerys
                                            .Include(b => b.Beers)
                                            .FirstOrDefaultAsync(b => b.Id == id);
            if (brewery == null)
                throw new NotFoundException("Le brasseur est pas trouvé");
            return brewery;
        }

        public async Task<Brewery> CreateBrewery(BreweryForCreationDTO breweryDto)
        {
            var newBrewery = new Brewery
            {
                Name = breweryDto.Name
            };
            Context.Brewerys.Add(newBrewery);
            await Context.SaveChangesAsync();

            return newBrewery;
        }

        public async Task<IEnumerable<BreweryForDisplayDto>> GetBrewerysStock()
        {
            IEnumerable<Brewery> brewerys = await GetBrewerys();
            List<BreweryForDisplayDto> brewerysDto = new List<BreweryForDisplayDto>();

            foreach (Brewery brewery in brewerys)
            {
                List<BeerForDisplayDto> beersDto = new List<BeerForDisplayDto>();

                if (brewery.Beers != null)
                {
                    foreach (Beer beer in brewery.Beers)
                    {
                        IEnumerable<Stock> stocks = await StockService.GetStocksFromBeer(beer.Id);
                        beersDto.Add(BeerForDisplayDto.FromBeer(beer, stocks.Select(s => StockForDisplayDto.FromStock(s, false)), false));
                    }
                }
                brewerysDto.Add(new BreweryForDisplayDto
                {
                    Id = brewery.Id,
                    Name = brewery.Name,
                    Beers = beersDto
                });
            }
            return brewerysDto;
        }

    }
}