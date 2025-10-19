using CompanyFeedback.API.Controllers;
using CompanyFeedback.Application.DTOs;
using CompanyFeedback.Application.Interfaces;
using CompanyFeedback.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyFeedback.Test
{
    public class CompanyTest : IClassFixture<TestFixture>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceScope _scope;
        private readonly ICompanyService _companyService;
        private readonly CompanyController _controller;

        public CompanyTest(TestFixture fixture)
        {
            _scope = fixture.ServiceProvider.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _companyService = _scope.ServiceProvider.GetRequiredService<ICompanyService>();
            _controller = new CompanyController(_companyService);
        }

        [Fact]
        public async Task Create_ShouldReturnSucess_WhenDataGiven()
        {
            // Arrange
            var dto = new CompanyCreateDto
            {
                Name = "Test Company",
                Description = "A company for testing",
                Website = "https://testcompany.com",
                Notes = "No additional notes",
                IsFinalCompany = false
            };

            // Act
            var result = await _controller.Create(dto);

            //Assert
            Assert.NotNull(result);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdCompany = Assert.IsType<CompanyReadDto>(createdResult.Value);
            Assert.Equal(1, createdCompany.Id);
            Assert.True(_context.Companies.Any(c => c.Name == "Test Company"));
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}