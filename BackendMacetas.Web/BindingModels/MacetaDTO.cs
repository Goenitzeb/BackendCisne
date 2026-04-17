namespace BackendMacetas.BindingModels;


public class MacetaDTO
{
    public string Nombre { get; set; } = null!;

    public int ColorId { get; set; }

    public int DisenoId { get; set; }

    public int ModeloId { get; set; }

    public int TamanoId { get; set; }

    public int Precio { get; set; }

    public int Stock { get; set; }
}
