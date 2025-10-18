using CompanyFeedback.Domain.Entities;
using CompanyFeedback.Domain.Interface.Repos;
using CompanyFeedback.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyFeedback.Infrastructure.Repos
{
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDbContext _context;
        private readonly DbSet<Company> _company;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
            _company = context.Companies;
        }

        public async Task<Company?> GetById(int id)
        {
            return await _company.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _company.ToListAsync();
        }

        public async Task<Company> Add(Company entity)
        {
            await _company.AddAsync(entity);
            return entity; ;
        }

        public Company Update(Company entity)
        {
            _company.Update(entity);
           return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var company = await GetById(id);
            if (company == null)
                return false;

            _company.Remove(company);
            return true;
        }
    }
}
