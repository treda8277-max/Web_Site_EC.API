using Domain.Entities;
using Domain.Interface;
using Infrastrcuture.AppDBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcuture.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetUserAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
