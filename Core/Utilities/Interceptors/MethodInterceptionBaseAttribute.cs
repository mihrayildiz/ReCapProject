//using Microsoft.EntityFrameworkCore.Diagnostics;
using Castle.DynamicProxy;


namespace Core.Utilities.Interceptors;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {

    }
}

// AllowMultiple = true : birden fazla yerde loglama yapmak isterse yani bir bye de yazdırmak isteyebilirdim bir dosyaya da yazdırmak isteyebilirdim.