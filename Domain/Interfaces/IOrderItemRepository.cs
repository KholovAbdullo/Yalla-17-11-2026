using Domain.Models;

namespace Domain.Interfaces;

public interface IOrderItemRepository
{
    Task<bool> AddOrderitem(Orderitems orderitem);
    Task<bool> UpdateOrderitem(int id,Orderitems orderitem);
    Task<bool> DeleteOrderitem(int id);
    Task<Orderitems> GetOrderitem(int id);
    Task<List<Orderitems>> GetOrderitems();
}
