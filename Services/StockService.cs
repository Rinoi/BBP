using BBP;
using BBP.Dto;
using BBP.Model;
using Microsoft.EntityFrameworkCore;

namespace BBP.Service
{
    public class StockService
    {
        private readonly ApplicationDbContext _context;

        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetStocks()
        {
            IEnumerable<Stock> stocks = await _context.Stocks
                                                .ToListAsync();
            return stocks;
        }

        public async Task<IEnumerable<Stock>> GetStocksFromBeer(int beerId)
        {
            IEnumerable<Stock> stocks = await _context.Stocks
                                                .Include(s => s.Wholesaler)
                                                .Where(s => s.BeerId == beerId)
                                                .ToListAsync();

            return stocks;
        }


        public async Task<Stock> UpdateStock(int wholesalerId, int beerId, int quantity)
        {
            if (await _context.Wholesalers.AnyAsync(w => w.Id == wholesalerId) == false)
                throw new NotFoundException("Le brasseur est pas trouvé");
            if (await _context.Beers.AnyAsync(b => b.Id == beerId) == false)
                throw new NotFoundException("Le biére est pas trouvé");

            //Add hash for more optimisation
            Stock? stock = await _context.Stocks.FirstOrDefaultAsync(s => s.WholesalerId == wholesalerId && s.BeerId == beerId);

            if (stock == null)
            {
                stock = new Stock()
                {
                    BeerId = beerId,
                    WholesalerId = wholesalerId,
                    Quantity = quantity
                };
                if (quantity == 0)
                    return stock;
                this._context.Stocks.Add(stock);
            }
            stock.Quantity = quantity;
            if (quantity == 0)
                this._context.Stocks.Remove(stock);
            await this._context.SaveChangesAsync();
            return stock;
        }
    }
}