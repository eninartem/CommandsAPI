using CommandAPI.Models;

namespace CommandAPI.Tests;

public class CommandTests : IDisposable
{
    private const string _howTo = "changed how to";
    private const string _platform = "changed platform";
    private const string _commandLine = "changed commandLine";

    Command _testCommand;

    public CommandTests()
    {
        _testCommand = new Command
        {
            HowTo = "Do something awesome",
            Platform = "xUnit",
            CommandLine = "dotnet test"
        };
    }

    [Fact]
    public void CanChangeHowTo()
    {
        //Act
        _testCommand.HowTo = _howTo;

        //Assert
        Assert.Equal(_howTo, _testCommand.HowTo);
    }

    [Fact]
    public void CanChangePlatform()
    {
        //Act
        _testCommand.Platform = _platform;

        //Assert
        Assert.Equal(_platform, _testCommand.Platform);
    }

    [Fact]
    public void CanChangeCommandLine()
    {
        //Act
        _testCommand.CommandLine = _commandLine;

        //Assert
        Assert.Equal(_commandLine, _testCommand.CommandLine);
    }

    public void Dispose()
    {
        _testCommand = null;
    }
}
