using Microsoft.EntityFrameworkCore;
using RO.DevTest.WebApi.Data;
using RO.DevTest.WebApi.Models;

namespace RO.DevTest.WebApi.Services
{
    public class SaleService
    {
        private readonly AppDbContext _context;

        public SaleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        public async Task<Sale> GetSaleByIdAsync(Guid id)
        {
            return await _context.Sales
                .Include(s => s.Client)
                .Include(s => s.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            sale.SaleDate = DateTime.UtcNow;
            sale.TotalAmount = sale.Items.Sum(i => i.Quantity * i.PriceAtSale);

            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<bool> DeleteSaleAsync(Guid id)
        {
            var sale = await GetSaleByIdAsync(id);
            if (sale == null) return false;

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
