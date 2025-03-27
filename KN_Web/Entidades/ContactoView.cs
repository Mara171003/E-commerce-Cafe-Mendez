using System.ComponentModel.DataAnnotations;

namespace KN_Web.Entidades
{
    // No es necesario aplicar [NotMapped] ya que ya no compite en nombre con la entidad de persistencia
    public class ContactoView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        public string Mensaje { get; set; }
    }
}

