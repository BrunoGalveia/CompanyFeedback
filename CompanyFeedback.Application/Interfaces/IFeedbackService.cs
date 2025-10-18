using CompanyFeedback.Application.DTOs;

namespace CompanyFeedback.Application.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackReadDto>> GetAllAsync();
        Task<FeedbackReadDto> GetAync(int id);
        Task<FeedbackReadDto> CreateAsync(FeedbackCreateDto feedback);
        Task<FeedbackReadDto> UpdateAsync(FeedbackUpdateDto feedback);
        Task<bool> DeleteAsync(int id);
    }
}
