

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Utils.Enum.Enums;
using System.ComponentModel;

namespace Domain.Entities
{
    public class Deporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }

        [ForeignKey("AreaDeportiva")] 
        public int AreaDeportivaId { get; set; }

        public AreaDeportiva? AreaDeportiva { get; set; }
    }
}
