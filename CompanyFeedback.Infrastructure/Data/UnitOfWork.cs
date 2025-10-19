using CompanyFeedback.Domain.Interface.Generic;
using CompanyFeedback.Domain.Interface.Repos;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CompanyFeedback.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICompanyRepository CompanyRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ICompanyRepository companyRepo, 
                IFeedbackRepository feedbackRepo)
        {
            _context = context;
            CompanyRepository = companyRepo;
            FeedbackRepository = feedbackRepo;
        }

        public async Task SaveChanges()
        {
            int numberOfChanges = 0;

            try
            {
                if (await _context.SaveChangesAsync() == 0)
                {
                    throw new Exception("No changes were made to the database.");
                }
            }
            catch (DbUpdateException ex)
            {
                
            }
            catch (DBConcurrencyException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public async Task Dispose()
        {
            _context.DisposeAsync();
        }

        //void IDisposable.Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
