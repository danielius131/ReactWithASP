using ReactWithAsp.Server.Models.DTOs;

namespace ReactyWithAsp.Server.Services;

public interface IGetStudentService
{
    Task<List<StudentDto>> GetAll();
    Task<StudentDto> Get(int id);
}