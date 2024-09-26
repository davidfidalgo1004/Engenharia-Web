using System.ComponentModel.DataAnnotations;

namespace Aula_2.Models
{
    public class Person
    {
        [Required(ErrorMessage="The fiel {0} is mandatory")]
        [Display(Name ="Login")]
        [DataType(DataType.Password)]   
        public string? name { get; set; } //ponto de interrogação, pois pode estar vazia
        [Required(ErrorMessage ="The fiel {0} is mandatory")]
        [Range(18,100,ErrorMessage ="{0} must be between {1} and {2}")]
        public int age { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "The fiel {0} is mandatory")]
        [DataType(DataType.EmailAddress)]
        public string? email {  get; set; }

    }
}
