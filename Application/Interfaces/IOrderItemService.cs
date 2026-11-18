using Application.DTOs.Orderitems;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IOrderItemService
{
    Task<ApiResponse<bool>> AddOrderitem(CreateOrderitemDto orderitem);
    Task<ApiResponse<bool>> UpdateOrderitem(int id,UpdateOrderitemDto orderitem);
    Task<ApiResponse<bool>> DeleteOrderitem(int id);
    Task<ApiResponse<OrderitemDto>> GetOrderitem(int id);
    Task<ApiResponse<List<OrderitemDto>>> GetOrderitems();
}
