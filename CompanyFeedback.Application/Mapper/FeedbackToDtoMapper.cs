using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Domain.Entities;

namespace CompanyFeedback.Application.Mapper
{
    public static class FeedbackToDtoMapper
    {
        public static FeedbackReadDto ToFeedbackReadDto(this Feedback feedback)
        {
            return new FeedbackReadDto
            {
                Id = feedback.Id,
                CompanyId = feedback.CompanyId,
                EmployeeName = feedback.EmployeeName,
                EmployeeEmail = feedback.EmployeeEmail,
                Comment = feedback.Comment,
                Type = feedback.Type,
                Avaliation = feedback.Avaliation,
                Interview = feedback.Interview != null ? feedback.Interview.ToInterviewDto() : null,
                Salary = feedback.Salary != null ? feedback.Salary.ToSalaryDto() : null
            };
        }

        public static Feedback ToFeedback(this FeedbackCreateDto feedbackDto)
        {
            return new Feedback
            {
                CompanyId = feedbackDto.CompanyId,
                EmployeeName = feedbackDto.EmployeeName,
                EmployeeEmail = feedbackDto.EmployeeEmail,
                Comment = feedbackDto.Comment,
                Type = feedbackDto.Type,
                Avaliation = feedbackDto.Avaliation,
                Interview = feedbackDto.Interview != null ? feedbackDto.Interview.ToInterview() : null,
                Salary = feedbackDto.Salary != null ? feedbackDto.Salary.ToSalary() : null
            };
        }

        public static Feedback ToFeedback(this FeedbackUpdateDto feedbackDto)
        {
            return new Feedback
            {
                Id = feedbackDto.Id,
                EmployeeName = feedbackDto.EmployeeName,
                EmployeeEmail = feedbackDto.EmployeeEmail,
                Comment = feedbackDto.Comment,
                Type = feedbackDto.Type,
                Avaliation = feedbackDto.Avaliation,
                Interview = feedbackDto.Interview != null ? feedbackDto.Interview.ToInterview() : null,
                Salary = feedbackDto.Salary != null ? feedbackDto.Salary.ToSalary() : null
            };
        }


        #region Interview Mapper
        public static Interview ToInterview(this InterviewDto interviewDto)
        {
            return new Interview
            {
                Id = interviewDto.Id,
                Type = interviewDto.Type,
                Duration = interviewDto.Duration,
                Comment = interviewDto.Comment,
                Avaliation = interviewDto.Avaliation
            };
        }

        public static InterviewDto ToInterviewDto(this Interview interview)
        {
            return new InterviewDto
            {
                Id = interview.Id,
                Type = interview.Type,
                Duration = interview.Duration,
                Comment = interview.Comment,
                Avaliation = interview.Avaliation
            };
        }
        #endregion

        #region Salary Mapper
        public static Salary ToSalary(this SalaryDto salaryDto)
        {
            return new Salary
            {
                Id = salaryDto.Id,
                BaseAmount = salaryDto.BaseAmount,
                BonusAmount = salaryDto.BonusAmount,
                MealAmount = salaryDto.MealAmount,
                Period = salaryDto.Period,
                Type = salaryDto.Type
            };
        }

        public static SalaryDto ToSalaryDto(this Salary salary)
        {
            return new SalaryDto
            {
                Id = salary.Id,
                BaseAmount = salary.BaseAmount,
                BonusAmount = salary.BonusAmount,
                MealAmount = salary.MealAmount,
                Period = salary.Period,
                Type = salary.Type
            };
        }
        #endregion
    }
}
