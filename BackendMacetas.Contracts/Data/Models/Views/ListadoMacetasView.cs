namespace BackendMacetas.Contracts.Data.Models.Views;

public class ListadoMacetasView : IEntity
{
    public int  Id { get; set; }

    public string Nombre { get; set; }

    public int Precio { get; set; }

    public int Stock { get; set; }

    public string Color { get; set; }

    public string Diseno { get; set; }

    public string Modelo { get; set; }

    public string Tamano { get; set; }
}
