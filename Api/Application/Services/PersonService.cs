using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDto>> Create(PersonDto personDto)
        {
            if (personDto == null)
                return ResultService.Fail<PersonDto>("Object must be informed");

            var result = new PersonDtoValidator { }.Validate(personDto);

            if (!result.IsValid)
                return ResultService.RequestError<PersonDto>("There was an error in validations", result);

            var person = _mapper.Map<Person>(personDto);
            var data = _personRepository.Create(person);

            return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(data));
        }
    }
}
