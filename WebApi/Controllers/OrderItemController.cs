using Application.DTOs.Orderitems;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IOrderItemService orderItemService) : ControllerBase
{
    private IOrderItemService service = orderItemService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrderitem(CreateOrderitemDto orderitem)
    {
        return await service.AddOrderitem(orderitem);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateOrderitem(int id,UpdateOrderitemDto orderitem)
    {
        return await service.UpdateOrderitem(id,orderitem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrderitem(int id)
    {
        return await service.DeleteOrderitem(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrderitemDto>> GetOrderitem(int id)
    {
        return await service.GetOrderitem(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<OrderitemDto>>> GetOrderitems()
    {
        return await service.GetOrderitems();
    }
}
