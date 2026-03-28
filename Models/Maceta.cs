using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendMacetas.Models
{
    [Table("macetas")]
    public class Maceta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Column("color_id")]
        public int ColorId { get; set; }

        [Column("diseno_id")]
        public int DisenoId { get; set; }

        [Column("modelo_id")]
        public int ModeloId { get; set; }

        [Column("tamano_id")]
        public int TamanoId { get; set; }

        [Column("precio")]
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public int Precio { get; set; }

        [Column("stock")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        public Color? Color { get; set; }
        public Diseno? Diseno { get; set; }
        public Modelo? Modelo { get; set; }
        public Tamano? Tamano { get; set; }
    }
}