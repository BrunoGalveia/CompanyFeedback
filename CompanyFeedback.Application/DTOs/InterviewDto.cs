using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Application.DTOs
{
    public class InterviewDto
    {
        public int Id { get; set; }
        public InterviewType Type { get; set; }
        public int Duration { get; set; }
        public string Comment { get; set; }
        public int Avaliation { get; set; }
    }
}
