using System.Net;
using Application.DTOs.Subscriptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class SubscriptionService(ISubscriptionRepository subscriptionRepository):ISubscriptionService
{
    private ISubscriptionRepository subscription = subscriptionRepository;

    public async Task<ApiResponse<bool>> AddSubscription(CreateSubscriptionDto subscription)
    {
        var subscriptions = new Subscriptions()
        {
            Companyid = subscription.Companyid,
            Plantype = subscription.Plantype,
            Mealsperday = subscription.Mealsperday,
            Price = subscription.Price,
            Startdate = subscription.Startdate,
            Enddate = subscription.Enddate
        };
        var res = await this.subscription.AddSubscription(subscriptions);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!", res);
    }

    public async Task<ApiResponse<bool>> DeleteSubscription(int id)
    {
        var res = await subscription.DeleteSubscription(id);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Detele!", res);
    }

    public async Task<ApiResponse<SubscriptionDto>> GetSubscription(int id)
    {
        var res = await subscription.GetSubscription(id);

        if (res == null)
        {
            return new ApiResponse<SubscriptionDto>(HttpStatusCode.NotFound, "Subscription not found!", null!);
        }
        var subscriptions = new SubscriptionDto()
        {
            id = res.id,
            Companyid = res.Companyid,
            Plantype = res.Plantype,
            Mealsperday = res.Mealsperday,
            Price = res.Price,
            Startdate = res.Startdate,
            Enddate = res.Enddate,
            isactive = res.isactive
        };
        return new ApiResponse<SubscriptionDto>(HttpStatusCode.OK, "Subscription!", subscriptions);
    }

    public async Task<ApiResponse<List<SubscriptionDto>>> GetSubscriptions()
    {
        var res = await subscription.GetSubscriptions();

        var subscriptions = res.Select(s => new SubscriptionDto
        {
            id = s.id,
            Companyid = s.Companyid,
            Plantype = s.Plantype,
            Mealsperday = s.Mealsperday,
            Price = s.Price,
            Startdate = s.Startdate,
            Enddate = s.Enddate,
            isactive = s.isactive
        }).ToList();

        return new ApiResponse<List<SubscriptionDto>>(HttpStatusCode.OK, "List Subscriptions!", subscriptions);
    }

    public async Task<ApiResponse<bool>> SubscriptionPatch(int id)
    {
        var res = await subscription.SubscriptionPatch(id);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "SubscriptionPatch!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Patch Subscription!", res);
    }

    public async Task<ApiResponse<bool>> UpdateSubscription(int id, UpdateSubscriptionDto subscription)
    {
        var subscriptions = new Subscriptions()
        {
            Companyid = subscription.Companyid,
            Plantype = subscription.Plantype,
            Mealsperday = subscription.Mealsperday,
            Price = subscription.Price,
            Startdate = subscription.Startdate,
            Enddate = subscription.Enddate
        };

        var res = await this.subscription.UpdateSubscription(id,subscriptions);
        return res == true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!", res);
    }

}
