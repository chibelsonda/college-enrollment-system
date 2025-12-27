using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEnrollmentSystem.Data;
using CollegeEnrollmentSystem.Models;
using CollegeEnrollmentSystem.ViewModels.Students;

namespace CollegeEnrollmentSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .AsNoTracking()
                .Select(s => new StudentListItemViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Age = s.Age
                })
                .ToListAsync();

            return View(students);
        }

        // GET: Students/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            var vm = new StudentDetailsViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age
            };

            return View(vm);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View(new StudentFormViewModel
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Age = 0
            });
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentFormViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Age = vm.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            var vm = new StudentFormViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age
            };

            return View(vm);
        }

        // POST: Students/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, StudentFormViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(vm);

            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            // Safe update (no blind overwrite)
            student.FirstName = vm.FirstName;
            student.LastName = vm.LastName;
            student.Email = vm.Email;
            student.Age = vm.Age;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Students/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
