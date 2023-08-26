

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Acceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }

        public Usuario UsuarioAsoc { get; set; }
    }
}
