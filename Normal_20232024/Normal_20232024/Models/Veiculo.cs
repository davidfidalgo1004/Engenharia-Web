using System.ComponentModel.DataAnnotations;

namespace Normal_20232024.Models
{
    public class Veiculo
    {
        [Key]
        public string? Matricula { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public int ProprietarioID { get; set; }
        public Proprietario? Proprietario { get; set; }
    }
}
