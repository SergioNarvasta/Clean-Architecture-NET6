
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Utils.Enums;

namespace Domain.Entities
{
    public class ComplejoDeportivo
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       [Required]
       public string Nombre { get; set; }
       [Required]
       public string Localizacion { get; set; }

        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }

        [Required]
       public int SedeOlimpicaId { get; set; }

        [ForeignKey("SedeOlimpicaId")]
        public SedeOlimpica? SedeOlimpica { get; set; }

       public Usuario? Usuario { get; set; }
       
    }
}
