using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Application.DTOs
{
    public class SalaryDto
    {
        public int BaseAmount { get; set; }
        public int? BonusAmount { get; set; }
        public int? MealAmount { get; set; }
        public Period Period { get; set; }
        public SalaryType Type { get; set; }
    }
}
