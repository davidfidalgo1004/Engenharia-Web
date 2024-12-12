using System.ComponentModel.DataAnnotations;

namespace Normal_20232024.Models
{
    public class Proprietario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage="Deve ter entre 5 e 200")]
        public string? Nome { get; set; }

        [Required]
        public  string? Nacionalidade { get; set; }

        public virtual IEnumerable<Veiculo>? Veiculos { get; set; }
    }
}
