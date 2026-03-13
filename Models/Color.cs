using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMacetas.Models
{
    [Table("colores")]
    public class Color
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;
    }
}
