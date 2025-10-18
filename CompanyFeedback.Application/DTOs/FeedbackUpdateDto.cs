using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Application.DTOs
{
    public class FeedbackUpdateDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string Comment { get; set; }
        public FeedbackType Type { get; set; }
        public int Avaliation { get; set; }
        public InterviewDto? Interview { get; set; }
        public SalaryDto? Salary { get; set; }
    }
}
