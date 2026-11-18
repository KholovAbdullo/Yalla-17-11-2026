using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderItemRepository(Database database):IOrderItemRepository
{
    private Database database1 = database;

    public async Task<bool> AddOrderitem(Orderitems orderitem)
    {
        database1.Orderitems.Add(orderitem);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteOrderitem(int id)
    {
        var res = await database1.Orderitems.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Orderitems.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Orderitems> GetOrderitem(int id)
    {
        var res = await database1.Orderitems.FirstOrDefaultAsync(x=>x.id==id);
        if (res == null)
        {
            return null!;
        }

        return res;
    }

    public async Task<List<Orderitems>> GetOrderitems()
    {
        return await database1.Orderitems.ToListAsync();
    }

    public async Task<bool> UpdateOrderitem(int id, Orderitems orderitem)
    {
        var res = await database1.Orderitems.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.Orderid=orderitem.Orderid;
            res.Menuitemid=orderitem.Menuitemid;
            res.Quantity=orderitem.Quantity;
            res.Price=orderitem.Price;
            res.Updatedat=orderitem.Updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
