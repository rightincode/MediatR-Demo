using System;
using LightInject;
using LightInject.ServiceLocation;
using MediatR;
using Microsoft.Practices.ServiceLocation;

namespace Request_Response
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = BuildMediator();

            //Console.WriteLine("Creating Message....");
            //var pingMessage = new Ping();

            //Console.WriteLine("Sending Message....");
            //string response = mediator.Send(pingMessage);

            //Console.WriteLine("Received Response....");
            //Console.Write("Response: ");
            //Console.WriteLine(response);

            //Console.WriteLine();

            Console.WriteLine("Creating Message....");
            var pingMessage2 = new Ping { PingId = 24 };

            Console.WriteLine("Sending Message....");
            string response2 = mediator.Send(pingMessage2);

            Console.WriteLine("Received Response....");
            Console.Write("Response: ");
            Console.WriteLine(response2);

            Console.ReadLine();

        }

        private static IMediator BuildMediator()
        {
            var container = new ServiceContainer();
            container.Register<IMediator, Mediator>();
            container.RegisterInstance<SingleInstanceFactory>(t => container.GetInstance(t));
            container.RegisterInstance<MultiInstanceFactory>(t => container.GetAllInstances(t));

            //register handlers
            container.Register<IRequestHandler<Ping, string>, PingHandler>();
            //container.RegisterAssembly(typeof(PingHandler).Assembly);

            var serviceLocator = new LightInjectServiceLocator(container);
            container.RegisterInstance(new ServiceLocatorProvider(() => serviceLocator));

            return container.GetInstance<IMediator>();
        }
    }
}
