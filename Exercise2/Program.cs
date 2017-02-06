using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new Connection("http://pcss.programmingjs.ch/ps");

            connection.Received += Connection_Received;
            connection.StateChanged += Connection_StateChanged;
            connection.Error += Connection_Error;

            connection.Start();
            Console.ReadLine();
        }

        private static void Connection_Error(Exception obj)
        {
            Console.Write($"Connection Error {obj.Message}");
        }

        private static void Connection_StateChanged(StateChange obj)
        {
            Console.Write($"Connection State changed {nameof(obj)}");
        }

        private static void Connection_Received(string obj)
        {
            Console.Write($"Connection received {nameof(obj)}");
        }
    }
}
