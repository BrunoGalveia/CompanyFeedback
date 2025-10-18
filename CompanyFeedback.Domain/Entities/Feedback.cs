using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? InterviewId { get; set; }
        public int? SalaryId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public FeedbackType Type { get; set; }
        public int Avaliation { get; set; }

        // Navigation property
        public Company Company { get; set; }
        public Interview Interview { get; set; }
        public Salary Salary { get; set; }

    }
}
