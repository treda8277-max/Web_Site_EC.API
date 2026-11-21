using Domain.Entities;

namespace Domain.Interface
{
    public interface ICartRpository
    {
        Task<Cart?> GetByUserIdAsync(int userId);
        Task AddAsync(Cart cart);
        Task AddItemCart(CartItem cartItem);
        Task UpdateItemAsync(CartItem cartItem);
        Task RemoveItemAsync(CartItem cartItem);
        Task ClearAsync(Cart cart);
    }
}
