using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using System.IO;
using System.Reflection;

using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;

using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Common;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            IConfigurationProvider configurationProvider = this.Kernel.Get<IConfigurationProvider>();
            this.Kernel.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Kernel.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Kernel.Bind<IParser>().To<CommandParserProvider>();

            this.Kernel.Bind<ICommand>().To<CreateStudentCommand>().Named(Constants.CreateStudentCommandName);
            this.Kernel.Bind<ICommand>().To<CreateTeacherCommand>().Named(Constants.CreateTeacherCommandName);
            this.Kernel.Bind<ICommand>().To<RemoveStudentCommand>().Named(Constants.RemoveStudentCommandName);
            this.Kernel.Bind<ICommand>().To<RemoveTeacherCommand>().Named(Constants.RemoveTeacherCommandName);
            this.Kernel.Bind<ICommand>().To<StudentListMarksCommand>().Named(Constants.StudentListMarksCommandName);
            this.Kernel.Bind<ICommand>().To<TeacherAddMarkCommand>().Named(Constants.TeacherAddMarkCommandName);

            if (configurationProvider.IsTestEnvironment)
            {
                this.Kernel.Bind<ICommandFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<ExecutionTimeInterceptor>();
                this.Kernel.Bind<IMarkFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<ExecutionTimeInterceptor>();
                this.Kernel.Bind<IStudentFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<ExecutionTimeInterceptor>();
                this.Kernel.Bind<ITeacherFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<ExecutionTimeInterceptor>();
            }
            else
            {
                this.Kernel.Bind<ICommandFactory>().ToFactory().InSingletonScope();
                this.Kernel.Bind<IMarkFactory>().ToFactory().InSingletonScope();
                this.Kernel.Bind<IStudentFactory>().ToFactory().InSingletonScope();
                this.Kernel.Bind<ITeacherFactory>().ToFactory().InSingletonScope();
            }
        }
    }
}