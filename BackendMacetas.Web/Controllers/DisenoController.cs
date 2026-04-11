using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;

[ApiController]
[Route("api/[controller]")]
public class DisenoController(ICollectionGetter<Diseno> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Diseno>> Get()
    {
        return await getter.GetAllAsync();
    }
}