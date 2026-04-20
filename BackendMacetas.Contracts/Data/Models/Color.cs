namespace BackendMacetas.Contracts.Data;

public class Color : IEntity
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
}
