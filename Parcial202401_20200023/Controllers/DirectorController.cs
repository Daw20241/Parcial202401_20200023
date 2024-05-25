using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial202401_20200023.Data;


namespace Parcial202401_20200023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        
            private readonly Parcial20240120200023Context _context;

            public DirectorController(Parcial20240120200023Context context)
            {
                _context = context;
            }

            
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Director>>> GetMovie()
            {
                var resultado = await _context.Director.ToListAsync();
                return Ok(resultado);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Director>> GetDirector(string id)
            {
                var director = await _context.Director.FindAsync(id);

                if (director == null)
                {
                    return NotFound();
                }

                return Ok(director);
            }

        
            [HttpPut("{id}")]
            public async Task<IActionResult> PutDirector(string id, Director director)
            {
                _context.Entry(director).State = EntityState.Modified;

                return Ok(await _context.SaveChangesAsync());
                
            }


            [HttpPost]
            public async Task<ActionResult<Movie>> PostMovie(Director director)
            {
                _context.Director.Add(director);
                
                var resultado =  await _context.SaveChangesAsync();
                
                return Ok(resultado);
            }

            
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDirector(string id)
            {
                var movie = await _context.Movie.FindAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }

                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }

