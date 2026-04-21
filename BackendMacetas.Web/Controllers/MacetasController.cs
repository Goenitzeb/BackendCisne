using AutoMapper;
using AutoMapper.Execution;
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
    IRepository<Maceta> repository,
    IMapper mapper) : ControllerBase
{
    [HttpGet, ActionName ("MacetasGet")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Maceta))]
    public async Task<IEnumerable<ListadoMacetasView>> Get()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Maceta>> Post(MacetaDTO bindinModel)
    {
        var maceta = mapper.Map<Maceta>(bindinModel);

        await repository.CreateAsync(maceta);

        return CreatedAtAction("MacetasGet", new { id = maceta.Id }, maceta);
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

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MacetaDTO bindingModel)
    {
        var maceta = mapper.Map<Maceta>(bindingModel);

        maceta.Id = id;

        await repository.UpdateAsync(maceta);

        return Ok(maceta);
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