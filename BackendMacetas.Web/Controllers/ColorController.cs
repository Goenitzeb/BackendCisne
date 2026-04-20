using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper; 


[ApiController]
[Route("api/[controller]")]
public class ColorController(
    ICollectionGetter<ListadoColorView> collectionGetter,
    IGetter<Color> getter,
    IRepository<Color> repository,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoColorView>> GetColores()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Color>> Post(ColorDTO bindinModel)
    {
        var color = mapper.Map<Color>(bindinModel);

        await repository.CreateAsync(color); 

        return CreatedAtAction(nameof(Get), new { id = color.Id }, color);
    }
}