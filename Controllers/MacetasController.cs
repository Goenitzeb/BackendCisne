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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var maceta = await _context.Macetas.FindAsync(id);

        if (maceta == null)
            return NotFound();

        _context.Macetas.Remove(maceta);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpGet("colores")]
    public async Task<IEnumerable<Color>> GetColores()
    {
        return await _context.Colores.ToListAsync();
    }

    [HttpGet("modelos")]
    public async Task<IEnumerable<Modelo>> GetModelos()
    {
        return await _context.Modelos.ToListAsync();
    }

    [HttpGet("disenos")]
    public async Task<IEnumerable<Diseno>> GetDisenos()
    {
        return await _context.Disenos.ToListAsync();
    }

    [HttpGet("tamanos")]
    public async Task<IEnumerable<Tamano>> GetTamanos()
    {
        return await _context.Tamanos.ToListAsync();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Maceta maceta)
    {
        if (id != maceta.Id)
            return BadRequest();

        _context.Entry(maceta).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Maceta>> Get(int id)
    {
        var maceta = await _context.Macetas
            .Include(m => m.Color)
            .Include(m => m.Diseno)
            .Include(m => m.Modelo)
            .Include(m => m.Tamano)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (maceta == null)
            return NotFound();

        return maceta;
    }

}