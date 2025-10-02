using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Models.DTOs;
using ReactyWithAsp.Server.Data;
using ReactyWithAsp.Server.Models.Entities;

namespace ReactyWithASP.Server.Services;

public class SaveStudentService(AppDbContext context) : ISaveStudentService
{
    public async Task Store(StudentDto dto)
    { 
        var student = new Student(dto.FirstName, dto.LastName, dto.Email);
        context.Students.Add(student);
        await context.SaveChangesAsync();

    }

    public async Task Update(int id, StudentDto dto)
    {
        var student = await context.Students.FirstOrDefaultAsync(i => i.id == id);
        if (student != null)
        { 
            student.SetValues(dto.FirstName, dto.LastName, dto.Email);
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }
    }
}
