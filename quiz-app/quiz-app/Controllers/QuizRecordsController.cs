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
using quiz_app.Repositories.QuizRecordInterface;

namespace quiz_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizRecordsController(IQuizRecordRepository quizRecordRepository, IMapper mapper) : ControllerBase
    {
        private readonly IQuizRecordRepository _quizRecordRepository = quizRecordRepository;
        public readonly IMapper _mapper = mapper;

        //// GET: api/QuizRecords
        [HttpGet]
        public async Task<List<QuizRecordResponseDTO>> GetQuizRecords([FromQuery] UserQuizRecordsDTO data)
        {
            var response = await _quizRecordRepository.GetQuizRecordsAsync(data);
            var result = _mapper.Map<List<QuizRecordResponseDTO>>(response);

            return result;
        }


        //// GET: api/QuizRecords/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<QuizRecord>> GetQuizRecord(Guid id)
        //{
        //    var quizRecord = await _context.QuizRecords.FindAsync(id);

        //    if (quizRecord == null)
        //    {
        //        return NotFound();
        //    }

        //    return quizRecord;
        //}

        //// PUT: api/QuizRecords/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuizRecord(Guid id, QuizRecord quizRecord)
        //{
        //    if (id != quizRecord.QuizRecordId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(quizRecord).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuizRecordExists(id))
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

        // POST: api/QuizRecords

        [HttpPost("createrecord")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<QuizRecord>> CreateQuizRecord([FromBody] QuizRecordDTO data)
        {
            try
            {
                var response = await _quizRecordRepository.CreateQuizRecordAsync(data);
                var result = _mapper.Map<QuizRecordResponseDTO>(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invalid User"))
                {
                    return BadRequest(ex.Message);
                }
                else if (ex.Message.Contains("Quiz Record Name already exist"))
                {
                    return Conflict(new { message = ex.Message });
                }
                else
                {
                    return StatusCode(500, "An unexpected error occurred: " + ex.Message);
                }
            }

        }

        // DELETE: api/QuizRecords/5
        [HttpDelete("{recordId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuizRecord(Guid recordId) 
        {
            var response = await _quizRecordRepository.DeleteQuizRecordAsync(recordId);

            return Ok(response);
        }

        //private bool QuizRecordExists(Guid id)
        //{
        //    return _context.QuizRecords.Any(e => e.QuizRecordId == id);
        //}
    }
}
