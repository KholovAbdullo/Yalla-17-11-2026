using Domain.Models;

namespace Domain.Interfaces;

public interface IMenuItemRepository
{
    Task<bool> AddMenuitem(Menuitems menuitem);
    Task<bool> UpdateMenuitem(int id,Menuitems menuitem);
    Task<bool> DeleteMenuitem(int id);
    Task<Menuitems> GetMenuitem(int id);
    Task<List<Menuitems>> GetMenuitems();
}
