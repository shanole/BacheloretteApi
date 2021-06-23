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
  [Route("api/bachelorettes/{bacheloretteId}/[controller]")]
  [ApiController]
  public class ContestantsController : ControllerBase
  {
    private readonly BacheloretteApiContext _db;
    public ContestantsController(BacheloretteApiContext db)
    {
      _db = db;
    }
    // GET api/bachelorette/1/contestants
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contestant>>> Get(int age, bool isEliminated) //example query: ?age=27 or ?isEliminated=false
    {
      var query = _db.Contestants.AsQueryable();
      if (age != 0) //string age = "12"  int intAge = 12
      {
        query = query.Where(entry => entry.Age == age);
      }
      if (isEliminated == true||false)
      {
        query = query.Where(entry => entry.IsEliminated == isEliminated);
      }
      return await query.ToListAsync();
    }
    // POST to api/bachelorette/1/contestants
    [HttpPost]
    public async Task<ActionResult<Contestant>> Post(int bacheloretteId, Contestant contestant)
    {
      contestant.BacheloretteId = bacheloretteId;
      _db.Contestants.Add(contestant);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetContestant), new { id = contestant.ContestantId, BacheloretteId = bacheloretteId }, contestant);
    }
    // Get contestant by id api/bachelorette/1/contestants/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Contestant>> GetContestant(int id)
    {
      var contestant = await _db.Contestants.FindAsync(id);
      if (contestant == null)
      {
        return NotFound();
      }
      return contestant;
    }

    //DELETE: api/bachelorette/1/contestants/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContestant(int id)
    {
      var contestant = await _db.Contestants.FindAsync(id);
      if (contestant == null)
      {
        return NotFound();
      }

      _db.Contestants.Remove(contestant);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    //PUT: api/bachelorette/1/contestants/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Contestant contestant)
    {
      if (id != contestant.ContestantId)
      {
        return BadRequest();
      }
      _db.Entry(contestant).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ContestantExists(id))
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

    private bool ContestantExists(int id)
    {
      return _db.Contestants.Any(e => e.ContestantId == id);
    }

  }
}

