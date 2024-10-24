using System.ComponentModel.DataAnnotations;

namespace Aula5.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage ="The {0} do not exceed {1} characteres")]
        public string? Title {  get; set; }
        [Required]
        public string? CoverPhoto { get; set; }
        [Required]
        public string? Document {  get; set; }
    }
}
