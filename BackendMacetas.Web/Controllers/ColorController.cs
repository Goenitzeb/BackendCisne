using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data;

[ApiController]
[Route("api/[controller]/color")]
public class ColorController(ICollectionGetter<Color> collectionGetter) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<Color>> GetColores()
    {
        return await collectionGetter.GetAllAsync();
    }
}