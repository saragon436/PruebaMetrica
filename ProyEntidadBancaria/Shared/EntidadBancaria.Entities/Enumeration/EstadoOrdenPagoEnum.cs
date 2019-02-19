using System.ComponentModel.DataAnnotations;

namespace EntidadBancaria.Entities.Enumeration
{
    public enum EstadoOrdenPagoEnum:byte
    {
        [Display(Name = "PAGADA")]
        Pagada = 1,
        [Display(Name = "DECLINADA")]
        Declinada = 2,
        [Display(Name = "FALLIDA")]
        Fallida = 3,
        [Display(Name = "ANULADA")]
        Anulada = 4
    }
}
