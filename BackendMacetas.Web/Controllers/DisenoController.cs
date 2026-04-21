using AutoMapper;
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
    IRepository<Diseno> repository,
    IMapper mapper) : ControllerBase
{
    [HttpGet, ActionName("DisenoGet")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ListadoDisenoView>> GetDisenos()
    {
        return await collectionGetter.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Diseno>> Post(DisenoDTO bindinModel)
    {
        var diseno = mapper.Map<Diseno>(bindinModel);

        await repository.CreateAsync(diseno);

        return CreatedAtAction("DisenoGet", new { id = diseno.Id }, diseno);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, DisenoDTO bindingModel)
    {
        var diseno = mapper.Map<Diseno>(bindingModel);

        diseno.Id = id;

        await repository.UpdateAsync(diseno);

        return Ok(diseno);
    }

}