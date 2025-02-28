using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quiz_app.Data;
using quiz_app.DTO;
using quiz_app.Entities;
using quiz_app.Repositories.QuizInterface;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController(IQuizRepository quizRepository, IMapper mapper) : ControllerBase
    {
        private readonly IQuizRepository _quizRepository = quizRepository;
        private readonly IMapper _mapper = mapper;

        //// GET: api/Quiz
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes()
        //{
        //    return await _context.Quizzes.ToListAsync();
        //}

        // GET: api/Quiz/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Quiz>> GetQuiz(Guid id)
        //{

        //}

        //// PUT: api/Quiz/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuiz(Guid id, Quiz quiz)
        //{
        //    if (id != quiz.QuizId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(quiz).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuizExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //POST: api/Quiz
        [HttpPost("addquiz")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Quiz>> AddQuiz([FromBody] QuizDTO data)
        {
            try
            {
                var response = await _quizRepository.CreateQuizAsync(data);
                var result = _mapper.Map<QuizResponseDTO>(response);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        //// DELETE: api/Quiz/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuiz(Guid id)
        //{
        //    var quiz = await _context.Quizzes.FindAsync(id);
        //    if (quiz == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Quizzes.Remove(quiz);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool QuizExists(Guid id)
        //{
        //    return _context.Quizzes.Any(e => e.QuizId == id);
        //}
    }
}
