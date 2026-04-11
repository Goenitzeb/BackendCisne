using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data.Models.Views;

[ApiController]
[Route("api/[controller]")]
public class DisenoController(ICollectionGetter<ListadoDisenoView> getter) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ListadoDisenoView>> Get()
    {
        return await getter.GetAllAsync();
    }
}