using Grpc.Net.Client;
using GRPCService.Endpoint;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new SuperHeroGetter.SuperHeroGetterClient(channel);
            LifeCycle(client);

        }

        private static async Task LifeCycle(SuperHeroGetter.SuperHeroGetterClient client)
        {

            Console.WriteLine("Which Superhero's identity do you want to unveil?");
            Console.WriteLine();

            var heroName = Console.ReadLine();

            var reply = client.GetAlterEgo(
             new AlterEgoRequest { Name = heroName }
             );

            Console.WriteLine($"Name: {reply.Name}");
            Console.WriteLine($"Age: {reply.Age}");
            Console.WriteLine($"Occupation: {reply.Occupation}");

            Console.WriteLine("Do you want to reveal another identity?(y/n)");
            var wantToContinue = Console.ReadLine();


            if (wantToContinue.Equals("y"))
            {
                await LifeCycle(client);
                return;
            }

            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
    }
}