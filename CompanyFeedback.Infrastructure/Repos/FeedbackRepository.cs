using CompanyFeedback.Domain.Entities;
using CompanyFeedback.Domain.Interface.Repos;
using CompanyFeedback.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyFeedback.Infrastructure.Repos
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private ApplicationDbContext _context;
        private readonly DbSet<Feedback> _feedback;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
            _feedback = context.Feedbacks;
        }

        public async Task<Feedback?> GetById(int id)
        {
            return await _feedback.FindAsync(id);
        }

        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await _feedback.ToListAsync();
        }

        public async Task<Feedback> Add(Feedback entity)
        {
            await _feedback.AddAsync(entity);
            return entity; ;
        }

        public Feedback Update(Feedback entity)
        {
            _feedback.Update(entity);
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var feedback = await GetById(id);
            if (feedback == null)
                return false;

            _feedback.Remove(feedback);
            return true;
        }
    }
}
