using Domain.Entities;
using Domain.Interface;
using Infrastrcuture.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcuture.Repository
{
    public class CartRpository : ICartRpository
    {
        private readonly AppDbContext _context;

        public CartRpository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            _context.SaveChanges();
        }

        public async Task AddItemCart(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            _context.SaveChanges();
        }

        public async Task ClearAsync(Cart cart)
        {
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public async Task<Cart?> GetByUserIdAsync(int userId) =>
            await _context.Carts.Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

        public async Task RemoveItemAsync(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public async Task UpdateItemAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }
    }
}
