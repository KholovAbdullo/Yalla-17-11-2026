using System.Net;
using Application.DTOs.Orderitems;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class OrderItemService(IOrderItemRepository orderItemRepository):IOrderItemService
{
    private IOrderItemRepository order = orderItemRepository;

    public async Task<ApiResponse<bool>> AddOrderitem(CreateOrderitemDto orderitem)
    {
        var orderitems = new Orderitems()
        {
            Orderid = orderitem.Orderid,
            Menuitemid = orderitem.Menuitemid,
            Quantity = orderitem.Quantity,
            Price = orderitem.Price
        };

        var res = await order.AddOrderitem(orderitems);

        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteOrderitem(int id)
    {
        var res = await order.DeleteOrderitem(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Detele!", res);
    }

    public async Task<ApiResponse<OrderitemDto>> GetOrderitem(int id)
    {
        var res = await order.GetOrderitem(id);
        if (res == null)
        {
            return new ApiResponse<OrderitemDto>(HttpStatusCode.NotFound, "Orderitem not found!", null!);
        }

        var orderitem = new OrderitemDto()
        {
            id = res.id,
            Orderid = res.Orderid,
            Menuitemid = res.Menuitemid,
            Quantity = res.Quantity,
            Price = res.Price,
            Createdat = res.Createdat,
            Updatedat = res.Updatedat
        };

        return new ApiResponse<OrderitemDto>(HttpStatusCode.OK, "Orderitem!", orderitem);
    }

    public async Task<ApiResponse<List<OrderitemDto>>> GetOrderitems()
    {
        var res = await order.GetOrderitems();
        var orderitems = res.Select(o=>new OrderitemDto
        {
            id = o.id,
            Orderid = o.Orderid,
            Menuitemid = o.Menuitemid,
            Quantity = o.Quantity,
            Price = o.Price,
            Createdat = o.Createdat,
            Updatedat = o.Updatedat
        }).ToList();

        return new ApiResponse<List<OrderitemDto>>(HttpStatusCode.OK, "List Orderitems!", orderitems);
    }

    public async Task<ApiResponse<bool>> UpdateOrderitem(int id, UpdateOrderitemDto orderitem)
    {
        var orderitems = new Orderitems()
        {
            Orderid = orderitem.Orderid,
            Menuitemid = orderitem.Menuitemid,
            Quantity = orderitem.Quantity,
            Price = orderitem.Price
        };
        var res = await order.UpdateOrderitem(id,orderitems);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Orderitem not found!", res);
    }

}
