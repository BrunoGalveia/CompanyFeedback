using CompanyFeedback.Application.Interfaces;
using CompanyFeedback.Application.Services;
using CompanyFeedback.Domain.Interface.Generic;
using CompanyFeedback.Domain.Interface.Repos;
using CompanyFeedback.Infrastructure.Data;
using CompanyFeedback.Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyFeedback.Test
{
    public class TestFixture : IDisposable
    {
        private IServiceProvider _serviceProvider;

        public TestFixture()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            // Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider => _serviceProvider;

        public void Dispose()
        {
            if (_serviceProvider is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
