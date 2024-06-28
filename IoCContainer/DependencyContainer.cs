namespace IoCContainer;

public class DependencyContainer
{
    private List<Type> _dependencies = new();

    public void AddDependency(Type type)
    {
        _dependencies.Add(type);
    }
    
    public void AddDependency<T>()
    {
        _dependencies.Add(typeof(T));
    }

    public Type GetDependency(Type type)
    {
        return _dependencies.First(d => d.Name == type.Name);
    }
}