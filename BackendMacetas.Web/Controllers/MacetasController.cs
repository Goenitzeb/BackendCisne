using Microsoft.AspNetCore.Mvc;
using BackendMacetas.Contracts.Services;
using BackendMacetas.Contracts.Data;
using BackendMacetas.Contracts.Data.Models.Views;

[ApiController]
[Route("api/[controller]/maceta")]
public class MacetasController(
    ICollectionGetter<ListadoMacetasView> collectionGetter,
    IGetter<Maceta> getter,
    IRepository<Maceta> repository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Maceta))]
    public async Task<IEnumerable<ListadoMacetasView>> Get()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Maceta>> Post(Maceta maceta)
    {
        await repository.CreateAsync(maceta);

        return CreatedAtAction(nameof(Get), new { id = maceta.Id }, maceta);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await repository.DeleteAsync(id);
        }catch(KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Maceta maceta)
    {
        if (id != maceta.Id)
            return BadRequest();

        await repository.UpdateAsync(maceta);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Maceta>> Get(int id)
    {
        var maceta = await getter.GetAsync(id);

        if (maceta == null)
            return NotFound();

        return maceta;
    }
}