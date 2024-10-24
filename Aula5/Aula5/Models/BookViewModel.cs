namespace Aula5.Models
{
    public class BookViewModel
    {
        

        public string? Title { get; set; }

        public IFormFile? CoverPhoto { get; set; }
  
        public IFormFile? Document { get; set; }
    }
}
