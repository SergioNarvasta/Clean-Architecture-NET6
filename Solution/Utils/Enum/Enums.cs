
using System.ComponentModel.DataAnnotations;

namespace Utils.Enum
{
    public class Enums
    {
        public enum Estados
        {
            [Display(Name = "Activo")]
            Active = 1,
            [Display(Name = "Inactivo")]
            Inactive = 0
        }
    }
}
