using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using CompanyFeedback.Application.Mapper;
using CompanyFeedback.Domain.Interface.Generic;
using CompanyFeedback.Domain.Interface.Repos;

namespace CompanyFeedback.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork _unitOfWOrk;
        private ICompanyRepository _companyRepo;

        public CompanyService(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
            _companyRepo = unitOfWOrk.CompanyRepository;
        }

        public async Task<CompanyReadDto> GetAync(int id)
        {
            var company = await _companyRepo.GetById(id);
            if (company == null)
                throw new Exception("Company not found");

            return company.ToCompanyReadDto();
        }

        public async Task<IEnumerable<CompanyReadDto>> GetAllAsync()
        {
            var companies = await _companyRepo.GetAll();
            return companies.Select(c => c.ToCompanyReadDto()).ToList();
        }

        public async Task<CompanyReadDto> CreateAsync(CompanyCreateDto companyDto)
        {
            var company = companyDto.ToCompany();
            var createdCompany = await  _companyRepo.Add(company);
            await _unitOfWOrk.SaveChanges();

            return createdCompany.ToCompanyReadDto();
        }

        public async Task<CompanyReadDto> UpdateAsync(CompanyUpdateDto companyDto)
        {
            if (!await _companyRepo.Any(companyDto.Id))
                throw new Exception("Company not found");

            var updatedCompany= companyDto.ToCompany();
            var company = _companyRepo.Update(updatedCompany);
            await _unitOfWOrk.SaveChanges();

            return company.ToCompanyReadDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _companyRepo.Delete(id);
            await _unitOfWOrk.SaveChanges();

            return result;
        }
    }
}
