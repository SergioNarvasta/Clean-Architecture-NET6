
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Utils.Enums;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Equipamiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }
        [Required]
        public int EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }
    }
}
