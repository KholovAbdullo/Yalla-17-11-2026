using Application.DTOs.Menuitems;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemController(IMenuItemService menuItemService) : ControllerBase
{
    private IMenuItemService service = menuItemService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMenuitem(CreateMenuitemDto menuitem)
    {
        return await service.AddMenuitem(menuitem);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateMenuitem(int id,UpdateMenuitemDto menuitem)
    {
        return await service.UpdateMenuitem(id,menuitem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMenuitem(int id)
    {
        return await service.DeleteMenuitem(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MenuitemDto>> GetMenuitem(int id)
    {
        return await service.GetMenuitem(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<MenuitemDto>>> GetMenuitems()
    {
        return await service.GetMenuitems();
    }
}
