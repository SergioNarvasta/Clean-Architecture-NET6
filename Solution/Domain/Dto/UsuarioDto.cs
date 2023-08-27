using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class AccesoDto
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
