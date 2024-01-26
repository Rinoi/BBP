using BBP;
using BBP.Dto;
using BBP.Model;
using Microsoft.EntityFrameworkCore;

namespace BBP.Service
{
    public class WholesalerService
    {
        private readonly ApplicationDbContext Context;

        public WholesalerService(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<Wholesaler>> GetWholesalers()
        {
            IEnumerable<Wholesaler> wholesalers = await this.Context.Wholesalers
                                                .Include(w => w.Stocks)
                                                    .ThenInclude(s => s.Beer)
                                                .ToListAsync();
            
            return wholesalers;
        }

        public async Task<Wholesaler> GetWholesaler(int id)
        {
            Wholesaler? wholesalers = await this.Context.Wholesalers
                                                .Include(w => w.Stocks)
                                                    .ThenInclude(s => s.Beer)
                                                .FirstOrDefaultAsync(w => w.Id == id);
            if (wholesalers == null)
                throw new NotFoundException("Le grosiste est pas trouvé");
            return wholesalers;
        }

        public async Task<Wholesaler> CreateWholesaler(WholesalerForCreationDTO breweryDto)
        {
            var newWholesaler = new Wholesaler
            {
                Name = breweryDto.Name
            };
            this.Context.Wholesalers.Add(newWholesaler);
            await this.Context.SaveChangesAsync();

            return newWholesaler;
        }

        public async Task<WholesalerDevisForResponseDTO> GetWholesalerDevis(WholesalerDevisForCreationDTO devisDto)
        {
            Wholesaler wholesaler = await GetWholesaler(devisDto.Id);
            double price = 0;
            int totalBeer = 0;

            if (devisDto.Stocks == null)
                throw new Exception("need stock for devis");
            foreach (StockDto stockDto in devisDto.Stocks)
            {
                Stock? stock = wholesaler.Stocks?.FirstOrDefault(s => s.BeerId == stockDto.BeerId);
                if (stock == null)
                    throw new NotFoundException("Le grossiste ne contien pas en stoque les bierres");
                if (stock.Quantity < stockDto.Quantity)
                    throw new NotFoundException("Le grossiste ne contien pas asse de biére");
                price += stock.Beer.Price * stockDto.Quantity;
                totalBeer += stockDto.Quantity;
            }
            // CHECK reduction
            if (totalBeer > 20)
                price *= 0.8;
            else if (totalBeer > 10)
                price *= 0.9;
            return new WholesalerDevisForResponseDTO
            {
                Id = devisDto.Id,
                Stocks = devisDto.Stocks,
                Price = price
            };
        }
    }
}