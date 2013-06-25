using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO.Ports;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup_();
            HttpListener listener = new HttpListener();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    listener.Prefixes.Add("http://" + ipAddress.ToString() + "/");
                }
            }
            
            listener.Start();

            while (listener.IsListening)
            {
                HttpListenerContext ctx = listener.GetContext();
                SendBluetoothCommand_(ctx.Request.RawUrl);
            }

            Console.WriteLine("Done");
        }

        private static void Startup_()
        {
            m_serialPort.Open();

            m_serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived_);
        }

        private static void SendBluetoothCommand_(string requestUrl)
        {
            Console.Out.WriteLine("Received the following web request:\n" + requestUrl);

            m_serialPort.Write("command");
        }

        private static void SerialDataReceived_(object sender, SerialDataReceivedEventArgs args)
        {
            Console.Out.WriteLine("\nReceived data from arduino:");
            while (m_serialPort.BytesToRead > 0)
                    Console.Out.Write((char)m_serialPort.ReadChar());
            Console.Out.WriteLine("\n");
        }
        
        private static System.IO.Ports.SerialPort m_serialPort = new SerialPort("COM12", 9600, Parity.None, 8, StopBits.One);
    }
}
