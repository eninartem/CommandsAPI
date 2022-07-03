using AutoMapper;

using CommandAPI.Data;
using CommandAPI.Dtos;

using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandAPIRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
        var items = _repository.GetAllCommands();

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(items));
    }

    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
        var item = _repository.GetCommandById(id);

        if (item == null) return NotFound();

        return Ok(_mapper.Map<CommandReadDto>(item));
    }
}
