﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyToDoApp.Views
{
	public partial class PluginsPage : ContentPage
	{
		public Command OpenPluginPage { get; set; } 

		public PluginsPage()
		{
			OpenPluginPage = new Command(parameter => Open(parameter));

			InitializeComponent();
		}

		private void Open(object parameter)
		{
			if ("Compass".Equals(parameter.ToString()))
			{
				Navigation.PushAsync(new CompassPage() { Title = "Compass" });
			}
			else if ("Camera".Equals(parameter.ToString()))
			{
				Navigation.PushAsync(new CameraPage() { Title = "Camera" });
			}
		}
	}
}
