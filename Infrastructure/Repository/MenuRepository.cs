using System.Security.Principal;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MenuRepository(Database database):IMenuRepository
{
    private Database database1 = database;

    public async Task<bool> AddMenu(Menus menu)
    {
        database1.Menus.Add(menu);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteMenu(int id)
    {
        var res = await database1.Menus.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Menus.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Menus> GetMenu(int id)
    {
       var res = await database1.Menus.FirstOrDefaultAsync(x=>x.id==id);
        if (res == null)
        {
            return null!;
        }

        return res;
    }

    public async Task<List<Menus>> GetMenus()
    {
        return await database1.Menus.ToListAsync();
    }

    public async Task<bool> MenuPatch(int id)
    {
        var res = await database1.Menus.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.isactive=false;
        }
        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<bool> UpdateMenu(int id, Menus menu)
    {
        var res = await database1.Menus.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.menudate=menu.menudate;
            res.updatedat=menu.updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
