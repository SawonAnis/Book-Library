namespace Book_Library_API.Models.DTOs
{
    public class UpdateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
    }
}
