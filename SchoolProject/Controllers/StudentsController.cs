using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data;
using SchoolProject.Models;
using SchoolProject.Models.Entities;

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
        //select * from students
        //inner join Field on...
        var students = await _context.Students
                        .Include(s => s.Field)
                        .Include(s => s.Notes)
                        .ThenInclude(n => n.Course)
                        .ThenInclude(c => c.Instructor)
                        .ToListAsync();

        var studentViewModels = students.Select(s => new StudentViewModel
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            FieldName = s.Field.Name,
            Courses = String.Join(", ", s.Notes.Select(n => n.Course.Name).Distinct()), //Select Name From Courses => Matematik, Fizik
            Instructors = String.Join(", ", s.Notes.Select(n => n.Course.Instructor.FirstName + " " + n.Course.Instructor.LastName).Distinct())
        }).ToList();

        var notes = _context.Notes.Include(n => n.Course).ThenInclude(c => c.Instructor);


        return View(studentViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        //int sayi = 10;
        //ViewBag.Sayi = 10; //Sayi = 10
        //ViewData["Sayi"] = 10; //Sayi = 10


        ViewBag.Fields = new SelectList(_context.Fields, "Id", "Name");

        //<option value="Field.Id" >Field.Name</option>
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

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {

        ViewBag.Fields = new SelectList(_context.Fields, "Id", "Name");
            
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {


        ViewBag.Fields = new SelectList(_context.Fields, "Id", "Name");

        _context.Students.Update(student);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {

        var student = await _context.Students
            .Include(s => s.Field)
            .Include(s => s.Notes)
            .ThenInclude(n => n.Course)
            .FirstOrDefaultAsync(s => s.Id == id);


        if (student == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }



        [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {

        var student = await _context.Students.Include(s => s.Field).FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    [HttpPost]
    public IActionResult Delete(Student student)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


}
