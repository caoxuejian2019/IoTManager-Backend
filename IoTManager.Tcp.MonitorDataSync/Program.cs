using System;

namespace IoTManager.Tcp.MonitorDataSync
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = "8080";
            SockerManager sockerManager = new SockerManager();
            sockerManager.StartMonitorLocalMachinePort(port);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
