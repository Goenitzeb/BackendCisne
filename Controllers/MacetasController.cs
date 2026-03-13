using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendMacetas.Models;
using BackendMacetas.Data;

[ApiController]
[Route("api/[controller]")]
public class MacetasController : ControllerBase
{
    private readonly AppDbContext _context;

    public MacetasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Maceta>> Get()
    {
        return await _context.Macetas
            .Include(m => m.Color)
            .Include(m => m.Diseno)
            .Include(m => m.Modelo)
            .Include(m => m.Tamano)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Maceta>> Post(Maceta maceta)
    {
        _context.Macetas.Add(maceta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = maceta.Id }, maceta);
    }
}