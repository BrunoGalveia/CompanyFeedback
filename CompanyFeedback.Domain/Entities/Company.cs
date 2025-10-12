namespace CompanyFeedback.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
        public bool IsFinalCompany { get; set; }

        // Navigation property
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
