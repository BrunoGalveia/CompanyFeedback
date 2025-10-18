namespace CompanyFeedback.Application.DTOs
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
        public bool IsFinalCompany { get; set; }
    }
}
