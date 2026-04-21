using AutoMapper;
using BackendMacetas.BindingModels;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;
using BackendMacetas.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TamanoController(
    ICollectionGetter<ListadoTamanoView> collectionGetter,
    IEntityCreator<TamanoDTO, Tamano> entityCreator,
    IGetter<Tamano> getter,
    IRepository<Tamano> repository,
    IMapper mapper) : ControllerBase
{
    [HttpGet, ActionName("TamanoGet")]
    public async Task<IEnumerable<ListadoTamanoView>> Get()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Tamano>> Post(TamanoDTO bindinModel)
    {
        var tamano = await entityCreator.CreateAsync(bindinModel);

        return CreatedAtAction("TamanoGet", new { id = tamano.Id }, tamano);
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