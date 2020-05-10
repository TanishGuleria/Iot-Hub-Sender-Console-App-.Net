using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Devices;
namespace IotHubSender
{
    class Program
    {
        static ServiceClient serviceClient;
        static string connectionString = "HostName=tsgiotdevice.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=uaxE25fpJzDBk+Vs2GhAZUfJOKccC3njedzC2NTLXU0=";
        static void Main(string[] args)
        {
            Console.WriteLine("Send Cloud-to-Device message\n");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            Console.WriteLine("Press any key to send a C2D message.");
            Console.ReadLine();
            SendCloudToDeviceMessageAsync().Wait();
            Console.ReadLine();
        }
        private async static Task SendCloudToDeviceMessageAsync()
        {
            var commandMessage = new
             Message(Encoding.ASCII.GetBytes("Cloud to device message."));
            await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }
    }
}
