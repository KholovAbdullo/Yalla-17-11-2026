using Application.DTOs.Orders;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<ApiResponse<bool>> AddOrder(CreateOrderDto order);
    Task<ApiResponse<bool>> UpdateOrder(int id,UpdateOrderDto order);
    Task<ApiResponse<bool>> DeleteOrder(int id);
    Task<ApiResponse<OrderDto>> GetOrder(int id);
    Task<ApiResponse<List<OrderDto>>> GetOrders();
}
