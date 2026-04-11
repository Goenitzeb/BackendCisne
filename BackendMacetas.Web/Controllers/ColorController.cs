using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;


[ApiController]
[Route("api/[controller]")]
public class ColorController(ICollectionGetter<ListadoColorView> collectionGetter) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoColorView>> GetColores()
    {
        return await collectionGetter.GetAllAsync();
    }
}