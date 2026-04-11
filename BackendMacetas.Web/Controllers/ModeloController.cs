using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data.Models.Views;

[ApiController]
[Route("api/[controller]")]
public class ModeloController(ICollectionGetter<ListadoModeloView> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ListadoModeloView>> Get()
    {
        return await getter.GetAllAsync();
    }
}