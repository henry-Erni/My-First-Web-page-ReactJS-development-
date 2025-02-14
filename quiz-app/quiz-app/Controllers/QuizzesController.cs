using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.Entities;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuizzesController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quizzes>>> GetQuizzes()
        {
            return await _context.Quizzes.ToListAsync();
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quizzes>> GetQuizzes(Guid id)
        {
            var quizzes = await _context.Quizzes.FindAsync(id);

            if (quizzes == null)
            {
                return NotFound();
            }

            return quizzes;
        }

        // PUT: api/Quizzes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizzes(Guid id, Quizzes quizzes)
        {
            if (id != quizzes.QuizId)
            {
                return BadRequest();
            }

            _context.Entry(quizzes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizzesExists(id))
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

        // POST: api/Quizzes
        [HttpPost]
        public async Task<ActionResult<Quizzes>> PostQuizzes(Quizzes quizzes)
        {
            _context.Quizzes.Add(quizzes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuizzes", new { id = quizzes.QuizId }, quizzes);
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizzes(Guid id)
        {
            var quizzes = await _context.Quizzes.FindAsync(id);
            if (quizzes == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quizzes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzesExists(Guid id)
        {
            return _context.Quizzes.Any(e => e.QuizId == id);
        }
    }
}
