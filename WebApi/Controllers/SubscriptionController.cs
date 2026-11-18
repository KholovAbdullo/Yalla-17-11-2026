using Application.DTOs.Subscriptions;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController(ISubscriptionService subscriptionService) : ControllerBase
{
    private ISubscriptionService service = subscriptionService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddSubscription(CreateSubscriptionDto subscription)
    {
        return await service.AddSubscription(subscription);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateSubscription(int id,UpdateSubscriptionDto subscription)
    {
        return await service.UpdateSubscription(id,subscription);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteSubscription(int id)
    {
        return await service.DeleteSubscription(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<SubscriptionDto>> GetSubscription(int id)
    {
        return await service.GetSubscription(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<SubscriptionDto>>> GetSubscriptions()
    {
        return await service.GetSubscriptions();
    }

    [HttpPatch("{id:int}")]
    public async Task<ApiResponse<bool>> SubscriptionPatch(int id)
    {
        return await service.SubscriptionPatch(id);
    }
}
