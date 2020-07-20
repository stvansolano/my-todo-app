using Xamarin.Forms;

namespace MyToDoApp.Views
{
	public partial class CardView
	{
		public CardView()
		{
			InitializeComponent();

			//if (Device.RuntimePlatform == Device.Android)
			//{
				HasShadow = Device.RuntimePlatform == Device.Android;
				BorderColor = Color.LightGray;

				Margin = Device.RuntimePlatform == Device.iOS ? new Thickness(10) : new Thickness(5);
			//}
		}
	}
}
