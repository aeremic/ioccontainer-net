namespace IoCContainer;

public class DependencyResolver
{
    private DependencyContainer _container;

    public DependencyResolver(DependencyContainer container)
    {
        _container = container;
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }

    public object GetService(Type type)
    {
        var dependency = _container.GetDependency(type);
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length > 0)
        {
            var parametersImplementations = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                parametersImplementations[i] = GetService(parameters[i].ParameterType);
            }

            return Activator.CreateInstance(dependency, parametersImplementations) ??
                   throw new InvalidOperationException();
        }

        return Activator.CreateInstance(dependency) ?? throw new InvalidOperationException();
    }
}