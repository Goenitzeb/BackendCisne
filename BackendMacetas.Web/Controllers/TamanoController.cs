using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;

[ApiController]
[Route("api/[controller]")]
public class TamanoController(ICollectionGetter<ListadoTamanoView> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ListadoTamanoView>> Get()
    {
        return await getter.GetAllAsync();
    }
}