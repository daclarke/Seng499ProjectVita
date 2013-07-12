using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace Blimp
{
	public partial class Enter_IP : Scene
	{
		public string IP;

		public Enter_IP ()
		{
			
			InitializeWidget ();
			EditableText_1.TextChanged += HandleEditableText_1TextChanged;
			
			Button_1.ButtonAction += HandleButton_1ButtonAction;
			
			
			
		}

		void HandleEditableText_1TextChanged (object sender, TextChangedEventArgs e)
		{
			Console.WriteLine (EditableText_1.Text);
			IP = EditableText_1.Text;
			
			
        	
		}

		void HandleButton_1ButtonAction (object sender, TouchEventArgs e)
		{
			Console.WriteLine ("GO button pressed");
			var nextScene = new Blimp.Main_screen ();
			UISystem.SetScene (nextScene, null);

			
			
		}

	
	}
}
