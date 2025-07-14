namespace GununSozu.Business.DTOs
{
    public class QuoteDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string LanguageName { get; set; } = string.Empty;
    }
}
