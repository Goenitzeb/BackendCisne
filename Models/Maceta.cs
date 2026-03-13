using System.ComponentModel.DataAnnotations.Schema;

namespace BackendMacetas.Models
{
    [Table("macetas")]
    public class Maceta
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
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
        public int Precio { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        public Color Color { get; set; } = null!;
        public Diseno Diseno { get; set; } = null!;
        public Modelo Modelo { get; set; } = null!;
        public Tamano Tamano { get; set; } = null!;
    }
}