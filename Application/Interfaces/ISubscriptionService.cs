using Application.DTOs.Subscriptions;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ISubscriptionService
{
    Task<ApiResponse<bool>> AddSubscription(CreateSubscriptionDto subscription);
    Task<ApiResponse<bool>> UpdateSubscription(int id,UpdateSubscriptionDto subscription);
    Task<ApiResponse<bool>> DeleteSubscription(int id);
    Task<ApiResponse<SubscriptionDto>> GetSubscription(int id);
    Task<ApiResponse<List<SubscriptionDto>>> GetSubscriptions();
    Task<ApiResponse<bool>> SubscriptionPatch(int id);
}
