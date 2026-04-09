using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data;

[ApiController]
[Route("api/[controller]/tamano")]
public class TamanoController(ICollectionGetter<Tamano> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Tamano>> Get()
    {
        return await getter.GetAllAsync();
    }
}