using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DisenoController(
    ICollectionGetter<ListadoDisenoView> collectionGetter,
    IGetter<Diseno> getter,
    IEntityCreator<DisenoDTO, Diseno> entityCreator,
    IEntityUpdater<DisenoDTO, Diseno> entityUpdater,
    IEntityDeleter<Diseno> entityDeleter
    ) : ControllerBase
{
    public const string GetName = "DisenoGet";

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoDisenoView>> GetAll()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpGet("{id}"), ActionName(GetName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Diseno>> Get(int id)
    {
        return await getter.GetAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Diseno>> Post(DisenoDTO bindinModel)
    {
        var entity = await entityCreator.CreateAsync(bindinModel);

        return CreatedAtAction(GetName, new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, DisenoDTO bindingModel)
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