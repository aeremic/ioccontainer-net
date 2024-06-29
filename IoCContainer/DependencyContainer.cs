namespace IoCContainer;

public class DependencyContainer
{
    private List<(Type, Type)> _dependencies = new();
    
    public void AddDependency<TConcrete, TInterface>()
    {
        _dependencies.Add((typeof(TConcrete), typeof(TInterface)));
    }

    public Type GetDependency(Type interfaceType)
    {
        return _dependencies.First(d => d.Item2.Name == interfaceType.Name).Item1;
    }
}