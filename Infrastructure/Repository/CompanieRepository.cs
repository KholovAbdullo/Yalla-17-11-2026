using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Date;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CompanieRepository(Database database):ICompanieRepository
{
    private Database database1 = database;

    public async Task<bool> AddCompanie(Companies Companie)
    {
        database1.Companies.Add(Companie);
        var res = await database1.SaveChangesAsync();
        return res>0;
    }

    public async Task<bool> DeleteCompanie(int id)
    {
        var res = await database1.Companies.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            database1.Companies.Remove(res);
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

    public async Task<Companies> GetCompanie(int id)
    {
        var res = await database1.Companies.FirstOrDefaultAsync(x=>x.id==id);
        if (res == null)
        {
            return null!;
        }
        return res;
    }

    public async Task<List<Companies>> GetCompanies()
    {
        return await database1.Companies.ToListAsync();
    }

    public async Task<bool> UpdateCompanie(int id, Companies Companie)
    {
        var res = await database1.Companies.FirstOrDefaultAsync(x=>x.id==id);
        if (res != null)
        {
            res.Name=Companie.Name;
            res.Address=Companie.Address;
            res.Phone=Companie.Phone;
            res.Email=Companie.Email;
            res.updatedat=Companie.updatedat;
        }

        var re = await database1.SaveChangesAsync();
        return re>0;
    }

}
