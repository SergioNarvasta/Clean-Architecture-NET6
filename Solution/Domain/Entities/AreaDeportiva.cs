
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Utils.Enums;
using System.ComponentModel;

namespace Domain.Entities
{
    public class AreaDeportiva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string IndLocalizacion { get; set; }

        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }

        public int? PolideportivoId { get; set; }
        [ForeignKey("PolideportivoId")]
        public Polideportivo? Polideportivo { get; set; }

        public Deporte? Deporte { get; set; }

        [ForeignKey("DeporteEspecifico")]
        public int? DeporteEspecificoid { get; set; }       
        public DeporteEspecifico? DeporteEspecifico { get; set; }

    }
}
