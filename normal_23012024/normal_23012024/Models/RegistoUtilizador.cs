using System.ComponentModel.DataAnnotations;

namespace normal_23012024.Models
{
    public class RegistoUtilizador
    {
        [Key]
        public int RegistoId { get; set; }
        [Required(ErrorMessage ="Nome Obrigatorio")]
        [StringLength(maximumLength:200, ErrorMessage ="Só pode ter até 200 caracteres")]
        public string? Nome { get; set; }
        [Required(ErrorMessage ="Obrigatorio")]
        [RegularExpression("Ordinário|Especial|Super")]
        public string? Regime { get; set; }
        public bool Valido { get; set; } = false;

    }
}
