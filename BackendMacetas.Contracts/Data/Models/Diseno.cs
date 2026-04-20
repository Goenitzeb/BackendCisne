namespace BackendMacetas.Contracts.Data;

public class Diseno : IEntity
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
}
