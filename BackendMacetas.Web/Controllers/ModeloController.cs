using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

[ApiController]
[Route("api/[controller]/modelo")]
public class ModeloController(ICollectionGetter<Modelo> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Modelo>> Get()
    {
        return await getter.GetAllAsync();
    }
}