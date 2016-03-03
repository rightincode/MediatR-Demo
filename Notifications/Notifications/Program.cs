using System;
using LightInject;
using LightInject.ServiceLocation;
using MediatR;
using Microsoft.Practices.ServiceLocation;

namespace Notifications
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = BuildMediator();

            Console.WriteLine("Creating Message....");
            var message = new NotificationMessage();

            Console.WriteLine("Sending Message....");
            mediator.Publish(message);

            Console.WriteLine();
            Console.WriteLine("Message sent....");

            Console.ReadLine();
        }

        private static IMediator BuildMediator()
        {
            var container = new ServiceContainer();
            container.Register<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.GetInstance(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.GetAllInstances(t));

            //register handlers
            container.RegisterAssembly(typeof (Receiver1).Assembly);
            //container.Register<INotificationHandler<NotificationMessage>, Receiver1>();
            //container.Register<INotificationHandler<NotificationMessage>, Receiver2>();
            //container.Register<INotificationHandler<NotificationMessage>, Receiver3>();
            //container.Register<INotificationHandler<NotificationMessage>, Receiver4>();
            //container.RegisterAssembly(typeof (INotificationHandler<NotificationMessage>).Assembly,
            //    (serviceType, implementationType) => implementationType.Namespace == "Notifications");
            //container.RegisterAssembly(typeof (INotificationHandler<NotificationMessage>).Assembly);

            var serviceLocator = new LightInjectServiceLocator(container);
            container.RegisterInstance(new ServiceLocatorProvider(() => serviceLocator));

            return container.GetInstance<IMediator>();
        }
    }
}
