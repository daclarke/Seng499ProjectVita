using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.UI;

namespace first_app
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		private static WebClient webClient = new WebClient ();
		private static string IP;		
				
		enum DirectionState
		{
			left = 1,
			right = 1 << 1,
			forward = 1 << 2,
			backward = 1 << 3
		}
		
		private static DirectionState previousAnalogState = 0;
		
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
			UISystem.Initialize (graphics);
			
			var scene = new Blimp.Enter_IP ();			
		
			UISystem.SetScene (scene, null);
			
		}


		public static void Update ()
		{
			// Query gamepad for current state
			
			EditableText editabletext = new EditableText();
			GamePadData gamePadData = GamePad.GetData (0);
			
			List<TouchData> touchDataList = Touch.GetData (0);
			
			UISystem.Update (touchDataList);
			
			
			
			String command = String.Empty;
			
			DirectionState analogState = 0;
			Console.WriteLine (gamePadData.AnalogLeftX);
			
			if (gamePadData.AnalogLeftX < (-0.25)) {
				command += "left";
				analogState |= DirectionState.left;
				
			} else if (gamePadData.AnalogLeftX > 0.25) {
				command += "right";
				analogState |= DirectionState.right;
			}
			if (gamePadData.AnalogRightY < -0.25) {
				if (!String.IsNullOrEmpty (command))
					command += "&";
				command += "up";
				analogState |= DirectionState.backward;
			} else if (gamePadData.AnalogRightY > 0.25) {
				if (!String.IsNullOrEmpty (command))
					command += "&";
				command += "down";
				analogState |= DirectionState.forward;
			}
			
			if (String.IsNullOrEmpty (command))
				command += "stop";
			
			
			
			if (previousAnalogState != analogState) {
				previousAnalogState = analogState;
				Console.WriteLine ("sending request");
				//change this to read from the text field
				TcpClient tcpClient = new TcpClient (editabletext.Text, 80);
				
				Byte[] bytes = Encoding.UTF8.GetBytes ("GET /" + command + " HTTP/1.0\n\n");
			
				tcpClient.GetStream ().Write (bytes, 0, bytes.Length);
			}

		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (1.0f, 1.0f, 1.0f, 1.0f);
			graphics.Clear ();
			
			
			UISystem.Render ();

			// Present the screen
			graphics.SwapBuffers ();
		}
	}
}
