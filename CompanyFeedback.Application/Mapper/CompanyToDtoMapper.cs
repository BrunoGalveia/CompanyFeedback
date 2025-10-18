using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Domain.Entities;

namespace CompanyFeedback.Application.Mapper
{
    public static class CompanyToDtoMapper
    {
        public static CompanyReadDto ToCompanyReadDto(this Company company)
        {
            return new CompanyReadDto
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Website = company.Website,
                Notes = company.Notes,
                IsFinalCompany = company.IsFinalCompany
            };
        }

        public static Company ToCompany(this CompanyCreateDto companyDto)
        {
            return new Company
            {
                Name = companyDto.Name,
                Description = companyDto.Description,
                Website = companyDto.Website,
                Notes = companyDto.Notes,
                IsFinalCompany = companyDto.IsFinalCompany
            };
        }

        public static Company ToCompany(this CompanyUpdateDto companyDto)
        {
            return new Company
            {
                Id = companyDto.Id,
                Name = companyDto.Name,
                Description = companyDto.Description,
                Website = companyDto.Website,
                Notes = companyDto.Notes,
                IsFinalCompany = companyDto.IsFinalCompany
            };
        }
    }
}
