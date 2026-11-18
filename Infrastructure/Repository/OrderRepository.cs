using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepository(Database database):IOrderRepository
{
    private Database database1 = database;

    public async Task<bool> AddOrder(Orders order)
    {
        database1.Orders.Add(order);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var res = await database1.Orders.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Orders.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Orders> GetOrder(int id)
    {
        var res = await database1.Orders.FirstOrDefaultAsync(x=>x.id==id);
        if (res == null)
        {
            return null!;
        }

        return res;
    }

    public async Task<List<Orders>> GetOrders()
    {
        return await database1.Orders.ToListAsync();
    }

    public async Task<bool> UpdateOrder(int id, Orders order)
    {
        var res = await database1.Orders.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.Companyid=order.Companyid;
            res.Orderdate=order.Orderdate;
            res.Status=order.Status;
            res.Totalamount=order.Totalamount;
            res.Updatedat=order.Updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
