using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace juans_app
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		
		private static WebClient webClient = new WebClient();
		
		private static GamePadButtons previousButtons = 0;
		
		public static void Main (string[] args)
		{
			Initialize ();

			while (true) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}
	
		
		public static void Initialize ()
		{
			// Set up the graphics system
			graphics = new GraphicsContext ();
				
		}

		public static void Update ()
		{
			// Query gamepad for current state
			GamePadData gamePadData = GamePad.GetData (0);
			GamePadButtons buttonsDown = gamePadData.Buttons;
			Console.WriteLine(buttonsDown);
			
			if (buttonsDown != previousButtons)
			{
				previousButtons = buttonsDown;
				Console.WriteLine("sending request");
				TcpClient tcpClient = new TcpClient("192.168.1.105",80);
				Byte[] bytes = Encoding.UTF8.GetBytes("GET /hello HTTP/1.0\n\n");
				tcpClient.GetStream().Write(bytes, 0, bytes.Length);
			}
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();

			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
