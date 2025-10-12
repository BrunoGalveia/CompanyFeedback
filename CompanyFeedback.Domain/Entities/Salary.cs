using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Domain.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public int BaseAmount { get; set; }
        public int? BonusAmount { get; set; }
        public int? MealAmount { get; set; }
        public Period Period { get; set; }
        public SalaryType Type { get; set; }

        public DateTime DateReported { get; set; }
        // Navigation property
        public Company Company { get; set; }
    }
}
