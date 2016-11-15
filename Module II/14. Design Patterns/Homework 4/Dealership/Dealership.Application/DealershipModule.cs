using System.IO;
using System.Reflection;

using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Framework.CommandProcessors;
using Dealership.Framework.Engine;
using Dealership.Framework.Factories;
using Dealership.Models;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Dealership.Application
{
    public class DealershipModule : NinjectModule
    {
        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";

        private const string AddCommentProcessorName = "AddCommentProcessor";
        private const string AddVehicleProcessorName = "AddVehiclesProcessor";
        private const string LoginProcessorName = "LoginProcessor";
        private const string LogoutProcessorName = "LogoutProcessor";
        private const string RegisterProcessorName = "RegisterProcessor";
        private const string RemoveCommentProcessorName = "RemoveCommentProcessor";
        private const string RemoveVehicleProcessorName = "RemoveVehicleProcessor";
        private const string ShowUsersProcessorName = "ShowUsersProcessor";
        private const string ShowVehiclesProcessorName = "ShowVehiclesProcessor";

        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IVehicle>().To<Car>().Named(CarName);
            this.Bind<IVehicle>().To<Motorcycle>().Named(MotorcycleName);
            this.Bind<IVehicle>().To<Truck>().Named(TruckName);

            this.Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>().InSingletonScope();

            this.Bind<IModelFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommentFactory>().ToFactory().InSingletonScope();
            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandProcessor>().To<AddCommentProcessor>().Named(AddCommentProcessorName);
            this.Bind<ICommandProcessor>().To<AddVehicleProcessor>().Named(AddVehicleProcessorName);
            this.Bind<ICommandProcessor>().To<LoginProcessor>().Named(LoginProcessorName);
            this.Bind<ICommandProcessor>().To<LogoutProcessor>().Named(LogoutProcessorName);
            this.Bind<ICommandProcessor>().To<RegisterProcessor>().Named(RegisterProcessorName);
            this.Bind<ICommandProcessor>().To<RemoveCommentProcessor>().Named(RemoveCommentProcessorName);
            this.Bind<ICommandProcessor>().To<RemoveVehicleProcessor>().Named(RemoveVehicleProcessorName);
            this.Bind<ICommandProcessor>().To<ShowUsersProcessor>().Named(ShowUsersProcessorName);
            this.Bind<ICommandProcessor>().To<ShowVehiclesProcessor>().Named(ShowVehiclesProcessorName);

            this.Bind<ICommandProcessor>().ToMethod(context =>
            {
                var registerCommandProcessor = context.Kernel.Get<ICommandProcessor>(RegisterProcessorName);
                var loginCommandProcessor = context.Kernel.Get<ICommandProcessor>(LoginProcessorName);
                var logoutCommandProcessor = context.Kernel.Get<ICommandProcessor>(LogoutProcessorName);
                var addVehicleCommandProcessor = context.Kernel.Get<ICommandProcessor>(AddVehicleProcessorName);
                var removeVehicleCommandProcessor = context.Kernel.Get<ICommandProcessor>(RemoveVehicleProcessorName);
                var addCommentCommandProcessor = context.Kernel.Get<ICommandProcessor>(AddCommentProcessorName);
                var removeCommentCommandProcessor = context.Kernel.Get<ICommandProcessor>(RemoveCommentProcessorName);
                var showUsersCommandProcessor = context.Kernel.Get<ICommandProcessor>(ShowUsersProcessorName);
                var showVehiclesCommandProcessor = context.Kernel.Get<ICommandProcessor>(ShowVehiclesProcessorName);

                registerCommandProcessor.SetSuccessor(loginCommandProcessor);
                loginCommandProcessor.SetSuccessor(logoutCommandProcessor);
                logoutCommandProcessor.SetSuccessor(addVehicleCommandProcessor);
                addVehicleCommandProcessor.SetSuccessor(removeVehicleCommandProcessor);
                removeVehicleCommandProcessor.SetSuccessor(addCommentCommandProcessor);
                addCommentCommandProcessor.SetSuccessor(removeCommentCommandProcessor);
                removeCommentCommandProcessor.SetSuccessor(showUsersCommandProcessor);
                showUsersCommandProcessor.SetSuccessor(showVehiclesCommandProcessor);
                showVehiclesCommandProcessor.SetSuccessor(null);

                return registerCommandProcessor;
            }).WhenInjectedInto<IEngine>();


            this.Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
        }
    }
}
