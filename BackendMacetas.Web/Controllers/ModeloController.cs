using AutoMapper;
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
    IRepository<Modelo> repository,
    IEntityUpdater<ModeloDTO, Modelo> entityUpdater,
    IMapper mapper) : ControllerBase
{
    [HttpGet, ActionName("ModeloGet")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoModeloView>> Get()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Modelo>> Post(ModeloDTO bindinModel)
    {
        var modelo = mapper.Map<Modelo>(bindinModel);

        await repository.CreateAsync(modelo);
        return CreatedAtAction("ModeloGet", new { id = modelo.Id }, modelo  );
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
            await repository.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return Ok();
    }

}