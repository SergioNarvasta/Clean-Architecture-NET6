

namespace Domain.Dto
{
    public class UsuarioAccesoDto : AccesoDto
    {
        
        public int Id { get; set; }   
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNac { get; set; }
        public int Estado { get; set; }

        
    }
}

