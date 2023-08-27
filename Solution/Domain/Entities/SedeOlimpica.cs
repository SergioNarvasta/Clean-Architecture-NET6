
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Utils.Enums;

namespace Domain.Entities
{
    public class SedeOlimpica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int NroComplejos { get; set; }
        [Required]
        public decimal Presupuesto { get; set; }

        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }
    }
}



