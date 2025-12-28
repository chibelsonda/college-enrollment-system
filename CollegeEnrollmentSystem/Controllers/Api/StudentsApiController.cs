using CollegeEnrollmentSystem.Data;
using CollegeEnrollmentSystem.DTOs;
using CollegeEnrollmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeEnrollmentSystem.Controllers.Api
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/students")]
    public class StudentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudents()
        {
            var students = await _context.Students
                .AsNoTracking()
                .Select(s => new StudentResponseDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Age = s.Age
                })
                .ToListAsync();

            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudent(Guid id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(new StudentResponseDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age
            });
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> CreateStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                new StudentResponseDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    Age = student.Age
                });
        }

        // PUT: api/students/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id, StudentUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
