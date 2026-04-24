using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ModeloController(
    ICollectionGetter<ListadoModeloView> collectionGetter,
    IGetter<Modelo> getter,
    IEntityUpdater<ModeloDTO, Modelo> entityUpdater,
    IEntityCreator<ModeloDTO, Modelo> entityCreator,
    IEntityDeleter<Modelo> entityDeleter
    ) : ControllerBase
{
    public const string GetName = "ModeloGet";

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoModeloView>> GetAll()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpGet("{id}"), ActionName(GetName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Modelo>> Get(int id)
    {
        return await getter.GetAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Modelo>> Post(ModeloDTO bindinModel)
    {
        var entity = await entityCreator.CreateAsync(bindinModel);

        return CreatedAtAction(GetName, new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ModeloDTO bindingModel)
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