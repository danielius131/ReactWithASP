using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactWithAsp.Server.Models.DTOs;
using ReactyWithAsp.Server.Services;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")
[Authorize]

public class StudentsController(AppDbContext context) : ControllerBase
{
    [HttpPut ("{id:int}")]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Put(int id, StudentDto dto)
    {
        var student = await context.Students.FirstOrDefaultAsync(i => i.id == id);
        if (student != null)
        {
            student.SetValues(dto.FirstName, dto.LastName, dto.Email);
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }

        return Ok();
    }   
}
public class StudentsControllers(AppDbContext context) : ControllerBase
{
    [HttpGet]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> GetAll()
    {
        var students = await context.Students.ToListAsync();
        List<StudentDto> results = [];

        foreach (var student in students)
        {
            results.Add(new StudentDto(student.id, student.FirstName, student.LastName, student.Email));
        }

        return Ok(results);
    }
}
public class StudentsControllers(IGetStudentService getStudentService, ISaveStudentService saveStudentService) : ControllerBase
{
    [HttpGet]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> GetAll()
    {
        var results = await getStudentService.GetAll();
        return Ok(results);
    }

    [HttpPut("{id:int}")]

    public async Task<IActionResult> Put(int id, StudentDto dto)
    {
        await saveStudentService.Update(id, dto);
        return Ok();
    }
}