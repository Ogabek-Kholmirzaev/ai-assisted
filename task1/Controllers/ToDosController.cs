using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Data.Models;

namespace task1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController(DataContext context) : ControllerBase
{
    private readonly DataContext context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDo>>> GetAll()
    {
        return await context.ToDos.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ToDo>> GetById(int id)
    {
        var toDo = await context.ToDos.FindAsync(id);
        if (toDo == null)
        {
            return NotFound();
        }

        return toDo;
    }

    [HttpPost]
    public async Task<ActionResult<ToDo>> Post([FromBody] ToDo toDo)
    {
        context.ToDos.Add(toDo);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = toDo.Id }, toDo);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ToDo toDo)
    {
        if (id != toDo.Id)
        {
            return BadRequest();
        }

        if (!await context.ToDos.AnyAsync(e => e.Id == id))
        {
            return NotFound();
        }

        context.Entry(toDo).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var toDo = await context.ToDos.FindAsync(id);
        if (toDo == null)
        {
            return NotFound();
        }

        context.ToDos.Remove(toDo);
        await context.SaveChangesAsync();

        return NoContent();
    }
}