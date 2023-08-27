
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DeporteEspecifico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Capacidad { get; set; }

        [Required]
        public int ComplejoDeportivoId { get; set; }

        [ForeignKey("ComplejoDeportivoId")]
        public ComplejoDeportivo? ComplejoDeportivo { get; set; }

        public AreaDeportiva? AreaDeportiva { get; set; }
    }
}
