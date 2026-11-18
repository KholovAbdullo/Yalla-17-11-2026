using Domain.Models;

namespace Domain.Interfaces;

public interface ICompanieRepository
{
    Task<bool> AddCompanie(Companies Companie);
    Task<bool> UpdateCompanie(int id,Companies Companie);
    Task<bool> DeleteCompanie(int id);
    Task<Companies> GetCompanie(int id);
    Task<List<Companies>> GetCompanies();
}
