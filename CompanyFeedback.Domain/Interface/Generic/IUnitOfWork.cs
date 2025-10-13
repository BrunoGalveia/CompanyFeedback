using CompanyFeedback.Domain.Interface.Repos;

namespace CompanyFeedback.Domain.Interface.Generic
{
    public interface IUnitOfWork //: IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IInterviewRepository InterviewRepository { get; }
        ISalaryRepository SalaryRepository { get; }

        Task SaveChanges();
        Task Dispose();
    }
}
