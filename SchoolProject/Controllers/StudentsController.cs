using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Entities;

namespace SchoolProject.Controllers;

public class StudentsController : Controller
{
    DatabaseContext _context;

    public StudentsController(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _context.Students.Include(s => s.Field).ToListAsync();

        var notes = _context.Notes.Include(n => n.Course).ThenInclude(c => c.Instructor);


        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Fields = new SelectList(_context.Fields, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {

        ViewBag.Fields = new SelectList(_context.Fields, "Id", "Name");

        _context.Students.Add(student);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
