using Application.DTOs.Menuitems;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IMenuItemService
{
    Task<ApiResponse<bool>> AddMenuitem(CreateMenuitemDto menuitem);
    Task<ApiResponse<bool>> UpdateMenuitem(int id,UpdateMenuitemDto menuitem);
    Task<ApiResponse<bool>> DeleteMenuitem(int id);
    Task<ApiResponse<MenuitemDto>> GetMenuitem(int id);
    Task<ApiResponse<List<MenuitemDto>>> GetMenuitems();
}
