using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BacheloretteApi.Models;

namespace BacheloretteApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BachelorettesController : ControllerBase
  {
    private readonly BacheloretteApiContext _db;
    public BachelorettesController(BacheloretteApiContext db)
    {
      _db = db;
    }
    // GET api/bachelorettes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bachelorette>>> Get()
    {
      return await _db.Bachelorettes.ToListAsync();
    }
    // POST api/bachelorettes
    [HttpPost]
    public async Task<ActionResult<IEnumerable<Bachelorette>>> Post(Bachelorette bachelorette)
    {
      _db.Bachelorettes.Add(bachelorette);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBachelorette), new { id = bachelorette.BacheloretteId }, bachelorette);

    }
    // Get Bachelorette by id api/bachelorettes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Bachelorette>> GetBachelorette(int id)
    {
      var bachelorette = await _db.Bachelorettes.FindAsync(id);
      if (bachelorette == null)
      {
        return NotFound();
      }
      return bachelorette;
    }

    //DELETE: api/bachelorette/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBachelorette(int id)
    {
      var bachelorette = await _db.Bachelorettes.FindAsync(id);
      if (bachelorette == null)
      {
        return NotFound();
      }

      _db.Bachelorettes.Remove(bachelorette);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    //PUT: api/bachelorette/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Bachelorette bachelorette)
    {
      if (id != bachelorette.BacheloretteId)
      {
        return BadRequest();
      }
      _db.Entry(bachelorette).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BacheloretteExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool BacheloretteExists(int id)
    {
      return _db.Bachelorettes.Any(e => e.BacheloretteId == id);
    }
  }
}