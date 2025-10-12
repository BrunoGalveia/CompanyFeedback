using CompanyFeedback.Domain.Enums;

namespace CompanyFeedback.Domain.Entities
{
    public class Interview
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public InterviewType Type { get; set; }
        public int Duration { get; set; }
        public string Comment { get; set; }
        public int Avaliation { get; set; }
        
        // Navigation property
        public Feedback Feedback { get; set; }
    }
}
