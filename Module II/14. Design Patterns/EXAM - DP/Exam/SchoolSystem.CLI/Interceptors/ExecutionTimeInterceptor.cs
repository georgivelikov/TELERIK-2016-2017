using System.Diagnostics;

using Ninject.Extensions.Interception;

using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interceptors
{
    public class ExecutionTimeInterceptor : IInterceptor
    {
        private IWriter writer;

        public ExecutionTimeInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch sw = new Stopwatch();
            this.writer.WriteLine(string.Format("Calling method {0} of type {1}...", invocation.Request.Method.Name, invocation.Request.Method.DeclaringType.Name));
            sw.Start();
            invocation.Proceed();
            sw.Stop();
            this.writer.WriteLine(string.Format("Total execution time for method {0} of type {1} is {2} milliseconds.", invocation.Request.Method.Name, invocation.Request.Method.DeclaringType.Name, sw.Elapsed.Milliseconds));
        }
    }
}
