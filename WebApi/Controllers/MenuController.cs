using Application.DTOs.Menus;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenuService menuService) : ControllerBase
{
    private IMenuService service = menuService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu)
    {
        return await service.AddMenu(menu);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMenu(int id,UpdateMenuDto menu)
    {
        return await service.UpdateMenu(id,menu);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        return await service.DeleteMenu(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MenuDto>> GetMenu(int id)
    {
        return await service.GetMenu(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<MenuDto>>> GetMenus()
    {
        return await service.GetMenus();
    }

    [HttpPatch("{id:int}")]
    public async Task<ApiResponse<bool>> MenuPatch(int id)
    {
        return await service.MenuPatch(id);
    }
}
