using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMacetas.Models
{
    [Table("tamanos")]
    public class Tamano
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;
    }
}
