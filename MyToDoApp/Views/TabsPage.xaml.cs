﻿using System;
using System.Linq;
using System.Windows.Input;
using AdventureWorks.SqlServer.Models;
using Microsoft.AppCenter.Crashes;
using Shared;
using Shared.WordPress;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using MyToDoApp.Services;
using AdventureWorks.SqlServer.Models;

namespace MyToDoApp.Views
{
	public partial class TabsPage
	{
		public TabsPage()
		{
			InitializeComponent();

			var aboutCommand = GetNavigationCommand(() => new AboutPage { Title = "About" });
			//AboutToolbarItem.Command = aboutCommand;

			//On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
			//On<Xamarin.Forms.PlatformConfiguration.iOS>().set(true);

            //MenuScreen.Menu.Add(GetMenuItem("Controls", new ControlsPage()));
            //MenuScreen.Menu.Add(GetMenuItem("Posts", new ItemsPage()));
			//MenuScreen.Menu.Add(GetMenuItem("Categories", new ItemsPage()));
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			IsBusy = true;

			try
			{
				var data = (await DependencyService.Get<IRepository<Product>>()
												   .GetAsync()).Take(5);

				MenuScreen.ViewModel.Menu.Clear();

				foreach (var item in data)
				{
					MenuScreen.ViewModel.Menu.Add(GetMenuItem(item.Name, new ItemDetailPage(item)));
				}
				MenuScreen.ViewModel.Menu.Add(GetMenuItem("See all Products", new ItemsPage()));
			}
			catch (Exception ex)
			{
				Crashes.TrackError(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		private MenuItem GetMenuItem(string title, Xamarin.Forms.Page page)
		{
			page.Title = title;

			return new MenuItem { Text = title, Command = GetNavigationCommand(() => page) };
		}

		private ICommand GetNavigationCommand(Func<Xamarin.Forms.Page> pageFunc)
		{
			return new Command(() =>
			{
				var page = pageFunc();

				Navigation.PushAsync(page);
			});
		}
	}
}