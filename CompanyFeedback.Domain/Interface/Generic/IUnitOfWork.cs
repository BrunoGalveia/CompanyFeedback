using CompanyFeedback.Domain.Interface.Repos;

namespace CompanyFeedback.Domain.Interface.Generic
{
    public interface IUnitOfWork //: IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }

        Task SaveChanges();
        Task Dispose();
    }
}
