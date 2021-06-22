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
  }
}