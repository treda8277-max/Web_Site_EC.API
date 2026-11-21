using Domain.Entities;
using Domain.Interface;
using Infrastrcuture.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcuture.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

        public async Task<Product?> GetByIdAsync(int id)
            => await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
            => await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
