using System.Net;
using Application.DTOs.Companies;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class CompanieService(ICompanieRepository companieRepository):ICompanieService
{
    private ICompanieRepository Compani = companieRepository;

    public async Task<ApiResponse<bool>> AddCompanie(CreateCompanyDto Companie)
    {
        var companies = new Companies()
        {
            Name=Companie.Name,
            Address=Companie.Address,
            Email=Companie.Email,
            Phone=Companie.Phone,
        };

        var res = await Compani.AddCompanie(companies);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Added!",res);
    }

    public async Task<ApiResponse<bool>> DeleteCompanie(int id)
    {
        var res = await Compani.DeleteCompanie(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Delete!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Delete!",res);
    }

    public async Task<ApiResponse<CompanyDto>> GetCompanie(int id)
    {
        var res = await Compani.GetCompanie(id);
        if (res == null)
        {
            return new ApiResponse<CompanyDto>(HttpStatusCode.NotFound, "Companie not Found!",null!);
        }

        var companie = new CompanyDto()
        {
            id=res.id,
            Name=res.Name,
            Address=res.Address,
            Phone=res.Phone,
            Email=res.Email,
            createdat=res.createdat,
            updatedat=res.updatedat
        };

        return new ApiResponse<CompanyDto>(HttpStatusCode.OK, "Companie!",companie);
    }

    public async Task<ApiResponse<List<CompanyDto>>> GetCompanies()
    {
        var res = await Compani.GetCompanies();
        var companie = res.Select(c=>new CompanyDto
        {
            id=c.id,
            Name=c.Name,
            Address=c.Address,
            Phone=c.Phone,
            Email=c.Email,
            createdat=c.createdat,
            updatedat=c.updatedat
        }).ToList();

        return new ApiResponse<List<CompanyDto>>(HttpStatusCode.OK, "List Companies!",companie);
    }

    public async Task<ApiResponse<bool>> UpdateCompanie(int id, UpdateCompanyDto Companie)
    {
        var companies = new Companies()
        {
            Name=Companie.Name,
            Address=Companie.Address,
            Email=Companie.Email,
            Phone=Companie.Phone,
        };

        var res = await Compani.UpdateCompanie(id,companies);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update!",res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Error Update!",res);
    }

}
