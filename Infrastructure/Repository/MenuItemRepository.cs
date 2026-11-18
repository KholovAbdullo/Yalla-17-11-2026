using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MenuItemRepository(Database database):IMenuItemRepository
{
    private Database database1 = database;

    public async Task<bool> AddMenuitem(Menuitems menuitem)
    {
        database1.Menuitems.Add(menuitem);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteMenuitem(int id)
    {
        var res = await database1.Menuitems.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Menuitems.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Menuitems> GetMenuitem(int id)
    {
        var menuitem = await database1.Menuitems.FirstOrDefaultAsync(x=>x.id==id);
        if (menuitem == null)
        {
            return null!;
        }

        return menuitem;
    }

    public async Task<List<Menuitems>> GetMenuitems()
    {
        return await database1.Menuitems.ToListAsync();
    }

    public async Task<bool> UpdateMenuitem(int id, Menuitems menuitem)
    {
        var res = await database1.Menuitems.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.Name=menuitem.Name;
            res.MenuId=menuitem.MenuId;
            res.Description=menuitem.Description;
            res.Price=menuitem.Price;
            res.Updatedat=menuitem.Updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
