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
    public async Task<ActionResult<IEnumerable<Contestant>>> Get()
    {
      return await _db.Contestants.ToListAsync();
    }
    // POST api/bachelorette/1/contestants
    [HttpPost]
    public async Task<ActionResult<Contestant>> Post(int bacheloretteId, Contestant contestant)
    {
      contestant.BacheloretteId = bacheloretteId;
      _db.Contestants.Add(contestant);
      await _db.SaveChangesAsync();
      // For some reason this didn't work with nameof(GetContestant)
      return CreatedAtAction("Post", new { id = contestant.ContestantId }, contestant);

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
  }
}