using Application.DTOs.Orders;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private IOrderService service = orderService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrder(CreateOrderDto order)
    {
        return await service.AddOrder(order);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateOrder(int id,UpdateOrderDto order)
    {
        return await service.UpdateOrder(id,order);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        return await service.DeleteOrder(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrderDto>> GetOrder(int id)
    {
        return await service.GetOrder(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<OrderDto>>> GetOrders()
    {
        return await service.GetOrders();
    }
}
