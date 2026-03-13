using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMacetas.Models
{
    [Table("modelos")]
    public class Modelo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;
    }
}
