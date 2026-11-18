using System.Net;
using Application.DTOs.Menus;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class MenuService(IMenuRepository menuRepository):IMenuService
{
    private IMenuRepository Menu = menuRepository;

    public async Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu)
    {
        var menus = new Menus()
        {
            menudate=menu.menudate
        };

        var res = await Menu.AddMenu(menus);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Error Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        var res = await Menu.DeleteMenu(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Deleted!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Error Detele!",res);
    }

    public async Task<ApiResponse<MenuDto>> GetMenu(int id)
    {
        var res = await Menu.GetMenu(id);
        if(res==null)
        {
            return new ApiResponse<MenuDto>(HttpStatusCode.NotFound,"Menu not found!",null!);
        }

        var menu = new MenuDto()
        {
            id=res.id,
            menudate=res.menudate,
            isactive=res.isactive,
            createdat=res.createdat,
            updatedat=res.updatedat
        };

        return new ApiResponse<MenuDto>(HttpStatusCode.OK,"Menu!",menu);
    }

    public async Task<ApiResponse<List<MenuDto>>> GetMenus()
    {
        var res = await Menu.GetMenus();
        var menus = res.Select(m=>new MenuDto()
        {
            id=m.id,
            menudate=m.menudate,
            isactive=m.isactive,
            createdat=m.createdat,
            updatedat=m.updatedat
        }).ToList();

        return new ApiResponse<List<MenuDto>>(HttpStatusCode.OK,"List Menus!",menus);
    }

    public async Task<ApiResponse<bool>> MenuPatch(int id)
    {
        var res = await Menu.MenuPatch(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Menu deactivated!",res)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Menu not found!",res);
    }

    public async Task<ApiResponse<bool>> UpdateMenu(int id, UpdateMenuDto menu)
    {
        var menus = new Menus()
        {
            menudate=menu.menudate,
            isactive=menu.isactive
        };

        var res = await Menu.UpdateMenu(id,menus);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Updated!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Menu not found!",res);
    }

}
