﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Models.DTOs;
using ReactyWithAsp.Server.Data;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentsController(AppDbContext context) : ControllerBase
{
    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var students = await context.Students.ToListAsync();
        List<StudentDto> results = [];

        foreach (var student in students)
        {
            results.Add(new StudentDto(student.Id, $"{student.FirstName} {student.LastName}", student.Email));
        }

        return Ok(results);
    }   
}
