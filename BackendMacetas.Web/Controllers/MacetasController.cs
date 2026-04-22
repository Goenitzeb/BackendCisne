using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MacetasController(
    ICollectionGetter<ListadoMacetasView> collectionGetter,
    IGetter<Maceta> getter,
    IEntityUpdater<MacetaDTO, Maceta> entityUpdater,
    IEntityCreator<MacetaDTO, Maceta> entityCreator,
    IEntityDeleter<Maceta> entityDeleter
    ) : ControllerBase
{
    public const string GetName = "MacetaGet";

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoMacetasView>> GetAll()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpGet("{id}"), ActionName(GetName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Maceta>> Get(int id)
    {
        return await getter.GetAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Maceta>> Post(MacetaDTO bindinModel)
    {
        var entity = entityCreator.CreateAsync(bindinModel);

        return CreatedAtAction(GetName, new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MacetaDTO bindingModel)
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