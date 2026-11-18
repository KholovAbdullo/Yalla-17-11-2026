using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class SubscriptionRepository(Database database):ISubscriptionRepository
{
    private Database database1 = database;

    public async Task<bool> AddSubscription(Subscriptions subscription)
    {
        database1.Subscriptions.Add(subscription);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteSubscription(int id)
    {
        var res = await database1.Subscriptions.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Subscriptions.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Subscriptions> GetSubscription(int id)
    {
        var res = await database1.Subscriptions.FirstOrDefaultAsync(x=>x.id==id);
        if (res == null)
        {
            return null!;
        }

        return res;
    }

    public async Task<List<Subscriptions>> GetSubscriptions()
    {
        return await database1.Subscriptions.ToListAsync();
    }

    public async Task<bool> SubscriptionPatch(int id)
    {
        var res = await database1.Subscriptions.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.isactive=false;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<bool> UpdateSubscription(int id, Subscriptions subscription)
    {
        var res = await database1.Subscriptions.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.Companyid=subscription.Companyid;
            res.Plantype=subscription.Plantype;
            res.Mealsperday=subscription.Mealsperday;
            res.Price=subscription.Price;
            res.Startdate=subscription.Startdate;
            res.Enddate=subscription.Enddate;
            res.Updatedat=subscription.Updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
