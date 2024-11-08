using System.ComponentModel.DataAnnotations;

namespace sistemainventariocms.Models
{
    public class Almacen
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El nombre no puede tener más de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "La Descripcion no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }
    }
}
