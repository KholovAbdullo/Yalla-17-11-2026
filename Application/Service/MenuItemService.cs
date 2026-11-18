using System.Net;
using Application.DTOs.Menuitems;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class MenuItemService(IMenuItemRepository menuItemRepository):IMenuItemService
{
    private IMenuItemRepository MenuItem = menuItemRepository;

    public async Task<ApiResponse<bool>> AddMenuitem(CreateMenuitemDto menuitem)
    {
        var menu = new Menuitems()
        {
            MenuId=menuitem.MenuId,
            Name=menuitem.Name,
            Description=menuitem.Description,
            Price=menuitem.Price,
            Category=menuitem.Category
        };

        var res = await MenuItem.AddMenuitem(menu);

        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteMenuitem(int id)
    {
        var res = await MenuItem.DeleteMenuitem(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!",res);
    }

    public async Task<ApiResponse<MenuitemDto>> GetMenuitem(int id)
    {
        var menu = await MenuItem.GetMenuitem(id);
        if (menu == null)
        {
            return new ApiResponse<MenuitemDto>(HttpStatusCode.NotFound, "Menuitem not fuond!",null!);
        }

        var res = new MenuitemDto()
        {
            id=menu.id,
            MenuId=menu.MenuId,
            Name=menu.Name,
            Description=menu.Description,
            Price=menu.Price,
            Category=menu.Category,
            Createdat=menu.Createdat,
            Updatedat=menu.Updatedat
        };

        return new ApiResponse<MenuitemDto>(HttpStatusCode.OK, "Menuitem!",res);
    }

    public async Task<ApiResponse<List<MenuitemDto>>> GetMenuitems()
    {
        var res = await MenuItem.GetMenuitems();
        var re = res.Select(m=>new MenuitemDto
        {
            id = m.id,
            MenuId = m.MenuId,
            Name = m.Name,
            Description = m.Description,
            Price = m.Price,
            Category = m.Category,
            Createdat = m.Createdat,
            Updatedat = m.Updatedat
        }).ToList();

        return new ApiResponse<List<MenuitemDto>>(HttpStatusCode.OK, "List Menuitems!",re);
    }

    public async Task<ApiResponse<bool>> UpdateMenuitem(int id, UpdateMenuitemDto menuitem)
    {
        var menu = new Menuitems()
        {
            MenuId=menuitem.MenuId,
            Name=menuitem.Name,
            Description=menuitem.Description,
            Price=menuitem.Price,
            Category=menuitem.Category
        };

        var res = await MenuItem.UpdateMenuitem(id,menu);

        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
