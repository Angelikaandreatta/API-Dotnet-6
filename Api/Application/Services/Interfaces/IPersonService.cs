using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDto>> Create(PersonDto personDto);
    }
}
