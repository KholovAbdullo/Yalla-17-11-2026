using Application.DTOs.Companies;
using Application.Responses;

namespace Application.Interfaces;

public interface ICompanieService
{
    Task<ApiResponse<bool>> AddCompanie(CreateCompanyDto Companie);
    Task<ApiResponse<bool>> UpdateCompanie(int id,UpdateCompanyDto Companie);
    Task<ApiResponse<bool>> DeleteCompanie(int id);
    Task<ApiResponse<CompanyDto>> GetCompanie(int id);
    Task<ApiResponse<List<CompanyDto>>> GetCompanies();
}
