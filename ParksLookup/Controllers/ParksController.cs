using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;

namespace ParksLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookupContext _db;

    public ParksController(ParksLookupContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Gets a list of national and state parks or allows query terms
    /// </summary>
    /// <returns>A list of national and state parks or by query term (parkid, parksystem,state, name, or activities)</returns>
    /// <remarks>
    /// 
    /// Sample requests:
    /// 
    /// GET: api/parks
    ///
    /// [
    ///   {
    ///       "parkId": 1,
    ///       "parkSystem": "National",
    ///       "state": "Wyoming",
    ///       "name": "Yellowstone",
    ///       "activities": "hiking, horseback riding, snowshoeing"
    ///   },
    ///   {
    ///       "parkId": 2,
    ///       "parkSystem": "National",
    ///       "state": "Colorado",
    ///       "name": "Black Canyon of the Gunnison",
    ///       "activities": "hiking, camping, astronomy"
    ///   },
    ///   {
    ///       "parkId": 3,
    ///       "parkSystem": "State",
    ///       "state": "Colorado",
    ///       "name": "Staunton State Park",
    ///       "activities": "hiking, sight-seeing, living history"
    ///   },
    ///   {
    ///      "parkId": 4,
    ///      "parkSystem": "State",
    ///      "state": "Texas",
    ///      "name": "Huntsville State Park",
    ///       "activities": "fishing, swimming, kayaking"
    ///   },
    ///   {
    ///       "parkId": 5,
    ///       "parkSystem": "State",
    ///       "state": "Wyoming",
    ///       "name": "Glendo State Park",
    ///       "activities": "boating, fishing, camping"
    ///   }
    /// ]
    /// 
    /// GET api/parks?parksystem=national
    /// ///   {
    ///       "parkId": 1,
    ///       "parkSystem": "National",
    ///       "state": "Wyoming",
    ///       "name": "Yellowstone",
    ///       "activities": "hiking, horseback riding, snowshoeing"
    ///   },
    ///   {
    ///       "parkId": 2,
    ///       "parkSystem": "National",
    ///       "state": "Colorado",
    ///       "name": "Black Canyon of the Gunnison",
    ///       "activities": "hiking, camping, astronomy"
    ///   },
    ///   
    ///   Note: activities can only be queried by a single activity
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string parkSystem, string state, string name, string activities)
    {
      var query = _db.Parks.AsQueryable();

      if (parkSystem != null)
      {
        query = query.Where(entry => entry.ParkSystem == parkSystem);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }    

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }      

      if (activities != null)
      {
        query = query.Where(entry => entry.Activities.Contains(activities));
      }    

      return await query.ToListAsync();
    }

    /// <summary>
    /// Gets a park by id
    /// </summary>
    /// <returns>a park by id</returns>
    /// <remarks>
    /// Sample request:
    ///
    /// GET: api/parks/1
    /// {
    ///   "parkId": 1,
    ///   "parkSystem": "National",
    ///   "state": "Wyoming",
    ///   "name": "Yellowstone",
    ///   "activities": "hiking, horseback riding, snowshoeing"
    /// }
    ///
    /// </remarks>
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }

    /// <summary>
    /// Edits a park by id
    /// </summary>
    /// <returns>204 No Content</returns>
    /// <remarks>
    /// Sample request:
    ///
    /// PUT: api/parks/7
    /// {
    ///   "parkId": 7,
    ///   "parkSystem": "National",
    ///   "state": "YourMom",
    ///   "name": "FakePark",
    ///   "activities": "getting lost"
    /// }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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

    /// <summary>
    /// Adds a park
    /// </summary>
    /// <returns>the added park</returns>
    /// <remarks>
    /// Sample request:
    ///
    /// POST: api/parks
    /// {
    ///   "parkSystem": "National",
    ///   "state": "YourMom",
    ///   "name": "FakePark",
    ///   "activities": "nothing to do"
    /// }
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }


    /// <summary>
    /// Deletes a park
    /// </summary>
    /// <returns>204 No Content</returns>
    /// <remarks>
    /// Sample request:
    ///
    /// DELETE: api/parks/5
    /// </remarks>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}