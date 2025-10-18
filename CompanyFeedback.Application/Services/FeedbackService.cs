using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using CompanyFeedback.Application.Mapper;
using CompanyFeedback.Domain.Interface.Generic;
using CompanyFeedback.Domain.Interface.Repos;

namespace CompanyFeedback.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IUnitOfWork _unitOfWOrk;
        private IFeedbackRepository _feedbackRepo;

        public FeedbackService(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
            _feedbackRepo = unitOfWOrk.FeedbackRepository;
        }

        public async Task<FeedbackReadDto> GetAync(int id)
        {
            var feedback = await _feedbackRepo.GetById(id);
            if (feedback == null)
                throw new Exception("Feedback not found");
            
            return feedback.ToFeedbackReadDto();
        }

        public async Task<IEnumerable<FeedbackReadDto>> GetAllAsync()
        {
            var feedbacks = await _feedbackRepo.GetAll();
            return feedbacks.Select(f => f.ToFeedbackReadDto()).ToList();
        }

        public async Task<FeedbackReadDto> CreateAsync(FeedbackCreateDto feedback)
        {
            var feedbackEntity = feedback.ToFeedback();
            var createdFeedback = await  _feedbackRepo.Add(feedbackEntity);
            await _unitOfWOrk.SaveChanges();

            return createdFeedback.ToFeedbackReadDto();
        }

        public async Task<FeedbackReadDto> UpdateAsync(FeedbackUpdateDto feedback)
        {
            var existingFeedback = await _feedbackRepo.GetById(feedback.Id);
            if (existingFeedback == null)
                throw new Exception("Feedback not found");

            var updatedFeedback= feedback.ToFeedback();
            var feedbackEntity = _feedbackRepo.Update(updatedFeedback);
            await _unitOfWOrk.SaveChanges();

            return feedbackEntity.ToFeedbackReadDto();
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _feedbackRepo.Delete(id);
            await _unitOfWOrk.SaveChanges();

            return result;
        }
    }
}
