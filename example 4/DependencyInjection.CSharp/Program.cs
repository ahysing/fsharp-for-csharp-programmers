using Autofac;
using System;

namespace DependencyInjection.CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This software demonstrates the Inversion of Control pattern.");
            var builder = new ContainerBuilder();
            // Register individual components
            builder.Register(c => new SQLite("./database.sqlite"))
                .As<IDatabase>();
            var container = builder.Build();
            var database = container.Resolve<IDatabase>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Document ID: " + database.NextDocumentId());
            }
        }
    }
}
