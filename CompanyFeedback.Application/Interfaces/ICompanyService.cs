using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Domain.Entities;

namespace CompanyFeedback.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyReadDto>> GetAllAsync();
        Task<CompanyReadDto> GetAync(int id);
        Task<CompanyReadDto> CreateAsync(CompanyCreateDto company);
        Task<CompanyReadDto> UpdateAsync(CompanyUpdateDto company);
        Task<bool> DeleteAsync(int id);
    }
}
