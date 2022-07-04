﻿using CommandAPI.Models;

namespace CommandAPI.Data;

public class SqlCommandAPIRepo : ICommandAPIRepo
{
    private readonly CommandContext _context;

    public SqlCommandAPIRepo(CommandContext context) => _context = context;

    public bool SaveChanges() => _context.SaveChanges() >= 0;

    public void CreateCommand(Command command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        _context.Commands.Add(command);
    }

    public void DeleteCommand(Command command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        _context.Commands.Remove(command);
    }

    public IEnumerable<Command> GetAllCommands()
    {
        return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
        return _context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public void UpdateCommand(Command command)
    {
        //throw new NotImplementedException();
    }
}
