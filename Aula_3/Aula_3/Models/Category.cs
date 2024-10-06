using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula_3.Models
{
    public class Category
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] Nesta linha se quisermos que seja introduzido pelo utilizador
        public int Id { get; set; } //É redondante, um campo chamado Id é sempre a chave primária
        [Required(ErrorMessage ="Required field")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="{0} length must be between {2} and {1}")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Required field")]
        [MaxLength(256, ErrorMessage ="{0} lenght can not exceed {1} characteres")]
        public string? Description { get; set; }
        public Boolean State { get; set; } = true;

        [DisplayName("Creation Name")]
        public DateTime Date {  get; set; }=DateTime.Now;
        
    }
}
