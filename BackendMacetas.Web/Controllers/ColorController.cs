using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class ColorController(
    ICollectionGetter<ListadoColorView> collectionGetter,
    IGetter<Color> getter,
    IEntityCreator<ColorDTO, Color> entityCreator,
    IEntityUpdater<ColorDTO, Color> entityUpdater,
    IEntityDeleter<Color> entityDeleter
    ) : ControllerBase
{
    public const string GetName = "ColorGet";

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoColorView>> GetAll()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpGet("{id}"), ActionName(GetName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Color>> Get(int id)
    {
        return await getter.GetAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Color>> Post(ColorDTO bindinModel)
    {
        var entity = entityCreator.CreateAsync(bindinModel);

        return CreatedAtAction(GetName, new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ColorDTO bindingModel)
    {
        var entity = await entityUpdater.UpdateAsync(id, bindingModel);

        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await entityDeleter.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}