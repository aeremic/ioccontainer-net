using NUnit.Framework;

namespace IoCContainer;

[TestFixture]
public class ContainerTest
{
    [Test]
    public void ContainerTestRun()
    {
        var container = new DependencyContainer();
        
        container.AddDependency<MainService>();
        container.AddDependency<HelloService>();
        container.AddDependency<MessageService>();

        var resolver = new DependencyResolver(container);
        
        var mainService = resolver.GetService<MainService>();
        mainService.RunService();
    }
}

public class MainService
{
    private HelloService _helloService;

    public MainService(HelloService helloService)
    {
        _helloService = helloService;
    }

    public void RunService()
    {
        _helloService.Hello();
    }
}

public class HelloService
{
    private MessageService _messageService;

    public HelloService(MessageService messageService)
    {
        _messageService = messageService;
    }

    public string Hello()
    {
        return $"Hello Service. {_messageService.Message}";
    }
}

public class MessageService
{
    public string Message()
    {
        return $"Message from Message Service.";
    }
}