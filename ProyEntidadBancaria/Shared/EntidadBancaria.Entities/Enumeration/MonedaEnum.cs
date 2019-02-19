using System.ComponentModel.DataAnnotations;

namespace EntidadBancaria.Entities.Enumeration
{
    public enum MonedaEnum:byte
    {
        [Display(Name = "SOLES")]
        Soles = 1,
        [Display(Name = "DOLARES")]
        Dolares = 2
    }
}
