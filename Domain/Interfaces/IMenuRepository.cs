using Domain.Models;

namespace Domain.Interfaces;

public interface IMenuRepository
{
    Task<bool> AddMenu(Menus menu);
    Task<bool> UpdateMenu(int id,Menus menu);
    Task<bool> DeleteMenu(int id);
    Task<Menus> GetMenu(int id);
    Task<List<Menus>> GetMenus();
    Task<bool> MenuPatch(int id);
}
