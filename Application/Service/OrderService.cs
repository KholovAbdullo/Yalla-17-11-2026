using System.Net;
using Application.DTOs.Orders;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class OrderService(IOrderRepository orderRepository):IOrderService
{
    private IOrderRepository order = orderRepository;

    public async Task<ApiResponse<bool>> AddOrder(CreateOrderDto order)
    {
        var orders = new Orders()
        {
            Companyid=order.Companyid,
            Orderdate=order.Orderdate,
            Status=order.Status,
            Totalamount=order.Totalamount
        };
        var res = await this.order.AddOrder(orders);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        var res = await order.DeleteOrder(id);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!", res);
    }

    public async Task<ApiResponse<OrderDto>> GetOrder(int id)
    {
        var res = await order.GetOrder(id);

        if (res == null)
        {
            return new ApiResponse<OrderDto>(HttpStatusCode.NotFound, "Order not found!", null!);
        }

        var orders = new OrderDto()
        {
            id = res.id,
            Companyid = res.Companyid,
            Orderdate=res.Orderdate,
            Status=res.Status,
            Totalamount=res.Totalamount
        };
        return new ApiResponse<OrderDto>(HttpStatusCode.OK, "Order!", orders);
    }

    public async Task<ApiResponse<List<OrderDto>>> GetOrders()
    {
        var res = await order.GetOrders();
        var orders = res.Select(o=>new OrderDto
        {
            id = o.id,
            Companyid = o.Companyid,
            Orderdate = o.Orderdate,
            Status = o.Status,
            Totalamount=o.Totalamount
        }).ToList();
        return new ApiResponse<List<OrderDto>>(HttpStatusCode.OK, "List Orders!", orders);
    }

    public async Task<ApiResponse<bool>> UpdateOrder(int id, UpdateOrderDto order)
    {
        var orders = new Orders()
        {
            Companyid=order.Companyid,
            Orderdate=order.Orderdate,
            Status=order.Status,
            Totalamount=order.Totalamount
        };
        var res = await this.order.UpdateOrder(id,orders);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }

}
