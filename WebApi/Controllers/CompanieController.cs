using Application.DTOs.Companies;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanieController(ICompanieService companieService) : ControllerBase
{
    private ICompanieService service = companieService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCompanie(CreateCompanyDto Companie)
    {
        return await service.AddCompanie(Companie);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCompanie(int id,UpdateCompanyDto Companie)
    {
        return await service.UpdateCompanie(id,Companie);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCompanie(int id)
    {
        return await service.DeleteCompanie(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CompanyDto>> GetCompanie(int id)
    {
        return await service.GetCompanie(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CompanyDto>>> GetCompanies()
    {
        return await service.GetCompanies();
    }
}
