using Domain.Models;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<bool> AddOrder(Orders order);
    Task<bool> UpdateOrder(int id,Orders order);
    Task<bool> DeleteOrder(int id);
    Task<Orders> GetOrder(int id);
    Task<List<Orders>> GetOrders();
}
