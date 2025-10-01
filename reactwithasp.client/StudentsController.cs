public class StuStudentsControllers(AppDbContext context) : ControllerBase
{
    [HttpGet]

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