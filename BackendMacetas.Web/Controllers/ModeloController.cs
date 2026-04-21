using AutoMapper;
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
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ListadoModeloView>> Get()
    {
        return await collectionGetter.GetAllAsync();
    }
}