using CommandAPI.Data;
using CommandAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommandAPIRepo _repository;

    public CommandsController(ICommandAPIRepo repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
        var items = _repository.GetAllCommands();

        return Ok(items);
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var item = _repository.GetCommandById(id);

        if (item == null) return NotFound();

        return Ok(item);
    }
}
