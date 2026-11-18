using Application.DTOs.Menus;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IMenuService
{
    Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu);
    Task<ApiResponse<bool>> UpdateMenu(int id,UpdateMenuDto menu);
    Task<ApiResponse<bool>> DeleteMenu(int id);
    Task<ApiResponse<MenuDto>> GetMenu(int id);
    Task<ApiResponse<List<MenuDto>>> GetMenus();
    Task<ApiResponse<bool>> MenuPatch(int id);
}
