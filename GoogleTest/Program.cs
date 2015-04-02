using System;
using System.Collections;
using System.Linq;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cmd = Console.ReadLine();

            if (cmd == "client")
            {
                var client = new Rpc.RpcClient("http://localhost:5050/");

                var proxy = client.CreateProxy<Sample>();
                var system = client.CreateProxy<system>();
                
                Console.WriteLine(proxy.Echo("hello world"));
                var ms = system.methodSignature("Sample.Echo");

                var m = (system.listMethods()).ToArray();
                
                foreach (var item in m)
                {
                    Console.WriteLine(item);
                }
            }
            else if (cmd == "server")
            {
                var server = new Rpc.RpcServer(5050);

                server.AddListener(new Sample());

                server.Start();
            }

            Console.ReadLine();
        }
    }
}