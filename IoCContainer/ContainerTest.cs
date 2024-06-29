using NUnit.Framework;
using Shouldly;

namespace IoCContainer;

[TestFixture]
public class ContainerTest
{
    [Test]
    public void ContainerTestRun()
    {
        // Setup
        var container = new DependencyContainer();

        container.AddDependency<MainService, IMainService>();
        container.AddDependency<HelloService, IHelloService>();
        container.AddDependency<MessageService, IMessageService>();

        var resolver = new DependencyResolver(container);

        // Running
        var mainService = resolver.GetService<IMainService>();
        var result = mainService.RunService();
            
        result.ShouldBe("PASSED");
    }
}

public interface IMainService
{
    public string RunService();
}

public class MainService : IMainService
{
    private IHelloService _helloService;

    public MainService(IHelloService helloService)
    {
        _helloService = helloService;
    }

    public string RunService()
    {
        return _helloService.Hello();
    }
}

public interface IHelloService
{
    public string Hello();
}

public class HelloService : IHelloService
{
    private IMessageService _messageService;

    public HelloService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public string Hello()
    {
        return $"{_messageService.Message()}";
    }
}

public interface IMessageService
{
    public string Message();
}

public class MessageService : IMessageService
{
    public MessageService()
    {
    }

    public string Message()
    {
        return $"PASSED";
    }
}