using BBP.Dto;
using BBP.Model;
using Microsoft.EntityFrameworkCore;

namespace BBP.Service
{
    public class BeerService
    {
        private readonly ApplicationDbContext Context;

        public BeerService(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<Beer>> GetBeers()
        {
            IEnumerable<Beer> beers = await this.Context.Beers
                                            .Include(b => b.Brewery)
                                            .ToListAsync();
            return beers;
        }

        public async Task<Beer> GetBeer(int id)
        {
            Beer? beer = await this.Context.Beers
                                    .Include(b => b.Brewery)
                                    .FirstOrDefaultAsync(b => b.Id == id);

            if (beer == null)
                throw new NotFoundException("La Bier a pas étati trouvé");
            return beer;
        }

        public async Task<Beer> CreateBeer(BeerForCreationDto beerDto)
        {
            if (!await BreweryExists(beerDto.BreweryId))
                throw new NotFoundException("La brasserie spécifiée n'existe pas.");

            Beer newBeer = new Beer
            {
                Name = beerDto.Name,
                AlcoholPercentage = beerDto.AlcoholPercentage,
                Price = beerDto.Price,
                BreweryId = beerDto.BreweryId
            };

            this.Context.Beers.Add(newBeer);
            await this.Context.SaveChangesAsync();

            return newBeer;
        }

        public async Task DeleteBeer(int id)
        {
            Beer? beer = await this.Context.Beers.FirstOrDefaultAsync(b => b.Id == id);
            bool hasStocks = await this.Context.Stocks.AnyAsync(s => s.BeerId == id);

            if (beer == null)
                throw new NotFoundException("La bière n'a pas été trouvée");
            if (hasStocks == true)
            {
                throw new Exception("Impossible de supprimer la bière car des stocks y sont liés.");
            }
            this.Context.Beers.Remove(beer);
            await this.Context.SaveChangesAsync();
        }


        private async Task<bool> BreweryExists(int breweryId)
        {
            return await this.Context.Brewerys.AnyAsync(b => b.Id == breweryId);
        }

    }
}
