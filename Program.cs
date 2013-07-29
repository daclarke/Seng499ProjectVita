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
            //comment next line
            Startup_();
            HttpListener listener = new HttpListener();
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    String listeningOn = "http://" + ipAddress.ToString() + "/";
                    listener.Prefixes.Add(listeningOn);
                    Console.WriteLine("Listening on: " + listeningOn);
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
            
            Console.WriteLine("Enter COM port (e.g. COM5). Will explode if enter port that doesn't work!");

            String serialPortString = Console.ReadLine();

            m_serialPort = new SerialPort(serialPortString, 9600, Parity.None, 8, StopBits.One);
            
            m_serialPort.Open();

            m_serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived_);
        }
       

        private static void SendBluetoothCommand_(string requestUrl)
        {
            string noSlash = requestUrl.Substring(1, requestUrl.Length - 1);

            Console.WriteLine("request:\n" + noSlash);

            string[] commands = noSlash.Split(new Char[] { '&' });

            String command = String.Empty;


           

            if (commands.Contains("stop"))
            {
                command = "l";
            }
            if (commands.Contains("left"))
            {
                command = "L";
            }
            if (commands.Contains("right"))
            {
                command = "R";
            }
            if (commands.Contains("forwards"))
            {
                command = "F";
            }
            if (commands.Contains("backwards"))
            {
                command = "V";
            }

            if (commands.Contains("elevate"))
            {
                command = "U";
            }
            if (commands.Contains("descend"))
            {
                command = "D";
            }

            if (commands.Contains("stopElevation"))
            {
                command = "u";
            }

            Console.Out.WriteLine("Sending command: " + command);
            
            //Comment this next line
            m_serialPort.Write(command);
            

        }

        private static void SerialDataReceived_(object sender, SerialDataReceivedEventArgs args)
        {
            Console.Out.WriteLine("\nReceived data from arduino:");
            while (m_serialPort.BytesToRead > 0)
                Console.Out.Write((char)m_serialPort.ReadChar());
            Console.Out.WriteLine("\n");
        }

        private static System.IO.Ports.SerialPort m_serialPort;
    }
}
