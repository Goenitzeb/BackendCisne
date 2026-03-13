using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMacetas.Models
{
    [Table("disenos")]
    public class Diseno
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;
    }
}
