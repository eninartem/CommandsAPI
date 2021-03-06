using AutoMapper;

using CommandAPI.Controllers;
using CommandAPI.Data;
using CommandAPI.Models;
using CommandAPI.Profiles;

using Microsoft.AspNetCore.Mvc;

using Moq;

namespace CommandAPI.Tests;

public class CommandsControllerTest : IDisposable
{
    Mock<ICommandAPIRepo> mockRepo;
    CommandsProfile realProfile;
    MapperConfiguration configuration;
    IMapper mapper;

    public CommandsControllerTest()
    {
        mockRepo = new Mock<ICommandAPIRepo>();
        realProfile = new CommandsProfile();
        configuration = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
        mapper = new Mapper(configuration);
    }
    public void Dispose()
    {
        mockRepo = null;
        mapper = null;
        configuration = null;
        realProfile = null;
    }

    [Fact]
    public void GetCommandItems_ReturnsZeroItems_WhenDBIsEmpty()
    {
        mockRepo
            .Setup(repo => repo.GetAllCommands())
            .Returns(GetCommands(0));

        var controller = new CommandsController(mockRepo.Object, mapper);

        //Act
        var result = controller.GetAllCommands();

        //Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    private List<Command> GetCommands(int num)
    {
        var commands = new List<Command>();

        if (num > 0)
        {
            commands.Add(new Command
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of migration>",
                Platform = ".Net Core EF"
            });
        }

        return commands;
    }
}
