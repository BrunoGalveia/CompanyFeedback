using CompanyFeedback.API.Controllers;
using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using CompanyFeedback.Domain.Entities;
using CompanyFeedback.Domain.Enums;
using CompanyFeedback.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyFeedback.Test
{
    public class FeedbackTest : IClassFixture<TestFixture>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceScope _scope;
        private readonly IFeedbackService _feedbackService;
        private readonly FeedbackController _controller;

        public FeedbackTest(TestFixture fixture)
        {
            _scope = fixture.ServiceProvider.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _feedbackService = _scope.ServiceProvider.GetRequiredService<IFeedbackService>();
            _controller = new FeedbackController(_feedbackService);
        }

        [Fact]
        public async Task Create_ShouldReturnSucess_WhenDataGiven()
        {
            // Arrange
            var company = CreateCompany();
            _context.Companies.Add(company);
            var dto = CreateStandardDto(company.Id);

            // Act
            var result = await _controller.Create(dto);

            //Assert
            Assert.NotNull(result);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdFeedback = Assert.IsType<FeedbackReadDto>(createdResult.Value);
            Assert.Equal(1, createdFeedback.Id);

            Assert.True(_context.Feedbacks.Any(f => f.EmployeeName == "John Doe"));
            Assert.True(_context.Interviews.Any(i => i.Duration == 60 && i.Avaliation == 5));
            Assert.True(_context.Salaries.Any(s => s.BaseAmount == 70000 && s.BonusAmount == 5000));
        }

        [Fact]
        public async Task Create_ShouldReturnSucess_WhenUpdateData()
        {
            // Arrange
            var company = CreateCompany();
            _context.Companies.Add(company);
            var feedback = CreateFeedback(company.Id);
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            _context.Entry(feedback).State = EntityState.Detached;

            // Act
            var updateDto = new FeedbackUpdateDto
            {
                Id = 1,
                EmployeeName = "Another John",
                EmployeeEmail = "",
                Comment = "Great place to work!",
                Type = FeedbackType.Interview,
                Avaliation = 5,
                Interview = new InterviewDto
                {
                    Id = 1,
                    Comment = "The interview process was smooth.",
                    Duration = 25,
                    Type = InterviewType.HR,
                    Avaliation = 5
                },
                Salary = new SalaryDto
                {
                    Id = 1,
                    BaseAmount = 456789,
                    BonusAmount = 200,
                    MealAmount = 2000,
                    Period = Period.Month,
                    Type = SalaryType.Net
                }
            };

            var result = await _controller.Update(1, updateDto);

            //Assert
            Assert.NotNull(result);

            var updatedResult = Assert.IsType<OkObjectResult>(result.Result);
            var updatedFeedback = Assert.IsType<FeedbackReadDto>(updatedResult.Value);
            Assert.Equal(1, _context.Feedbacks.Count());
            Assert.Equal(1, _context.Interviews.Count());
            Assert.Equal(1, _context.Salaries.Count());
            Assert.False(_context.Feedbacks.Any(f => f.EmployeeName == "John Doe"));
            Assert.False(_context.Interviews.Any(i => i.Duration == 60 && i.Avaliation == 5));
            Assert.False(_context.Salaries.Any(s => s.BaseAmount == 70000 && s.BonusAmount == 5000));
        }

        #region Helpers
        
        private Company CreateCompany()
        {
            return new Company
            {
                Id = 1,
                Name = "Test Company",
                Description = "A company for testing",
                Website = "https://testcompany.com",
                Notes = "No additional notes",
                IsFinalCompany = false
            };
        }

        private Feedback CreateFeedback(int companyId)
        {
            return new Feedback
            {
                Id = 1,
                CompanyId = 1,
                EmployeeName = "John Doe",
                EmployeeEmail = "",
                Comment = "Great place to work!",
                Type = FeedbackType.Interview,
                Avaliation = 5,
                Interview = new Interview
                {
                    Id = 1,
                    Comment = "The interview process was smooth.",
                    Duration = 60,
                    Type = InterviewType.HR,
                    Avaliation = 5
                },
                Salary = new Salary
                {
                    Id = 1,
                    BaseAmount = 70000,
                    BonusAmount = 5000,
                    MealAmount = 2000,
                    Period = Period.Month,
                    Type = SalaryType.Net
                }
            };
        }

        private FeedbackCreateDto CreateStandardDto(int companyId)
        {
            return new FeedbackCreateDto
            {
                CompanyId = companyId,
                EmployeeName = "John Doe",
                EmployeeEmail = "",
                Comment = "Great place to work!",
                Type = FeedbackType.Interview,
                Avaliation = 5,
                Interview = new InterviewDto
                {
                    Comment = "The interview process was smooth.",
                    Duration = 60,
                    Type = InterviewType.HR,
                    Avaliation = 5
                },
                Salary = new SalaryDto
                {
                    BaseAmount = 70000,
                    BonusAmount = 5000,
                    MealAmount = 2000,
                    Period = Period.Month,
                    Type = SalaryType.Net
                }
            };
        }
        #endregion

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}