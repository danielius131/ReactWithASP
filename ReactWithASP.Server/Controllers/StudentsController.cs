using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Models.DTOs;
using ReactyWithAsp.Server.Data;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentsController(AppDbContext context) : ControllerBase
{
    [HttpPut ("{id:int}")]

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
