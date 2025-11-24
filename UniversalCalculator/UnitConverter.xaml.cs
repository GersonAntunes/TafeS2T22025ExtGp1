using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class UnitConverter : Page
	{
		public UnitConverter()
		{
			this.InitializeComponent();
		}

		private async void temperatureButton_Click(object sender, RoutedEventArgs e)
		{
			double temp = 0;
			try
			{
				temp = int.Parse(inputTextBox.Text);
			}
			catch (Exception ex)
			{
				var popUp = new MessageDialog(ex.Message);
				await popUp.ShowAsync();
				inputTextBox.Text = "";
				inputTextBox.Focus(FocusState.Programmatic);
				return;
			}
			
			if (title.Text == "Metric to Imperial")
			{
				temp = (temp * 1.8) + 32;
			}
			else if (title.Text == "Imperial to Metric")
			{
				temp = (temp - 32) / 1.8;
			}
			outputTextBox.Text = Math.Round(temp,4).ToString();
		}

		private async void distanceButton_Click(object sender, RoutedEventArgs e)
		{
			double dist = 0;
			try
			{
				dist = int.Parse(inputTextBox.Text);
			}
			catch (Exception ex)
			{
				var popUp = new MessageDialog(ex.Message);
				await popUp.ShowAsync();
				inputTextBox.Text = "";
				inputTextBox.Focus(FocusState.Programmatic);
				return;
			}

			if(title.Text == "Metric to Imperial")
			{
				dist = dist * 3.28084;
			}
			else if(title.Text == "Imperial to Metric")
			{
				dist = dist / 3.28084;
			}
			outputTextBox.Text = Math.Round(dist,4).ToString();
		}

		private async void massButton_Click(object sender, RoutedEventArgs e)
		{
			double mass = 0;
			try
			{
				mass = int.Parse(inputTextBox.Text);
			}
			catch (Exception ex)
			{
				var popUp = new MessageDialog(ex.Message);
				await popUp.ShowAsync();
				inputTextBox.Text = "";
				inputTextBox.Focus(FocusState.Programmatic);
				return;
			}

			if(title.Text == "Metric to Imperial")
			{
				mass = mass * 2.20462;
			}
			else if(title.Text == "Imperial to Metric")
			{
				mass = mass / 2.20462;
			}
			outputTextBox.Text = Math.Round(mass,4).ToString();
		}

		private async void pressureButton_Click(object sender, RoutedEventArgs e)
		{
			double press = 0;
			try
			{
				press = int.Parse(inputTextBox.Text);
			}
			catch (Exception ex)
			{
				var popUp = new MessageDialog(ex.Message);
				await popUp.ShowAsync();
				inputTextBox.Text = "";
				inputTextBox.Focus(FocusState.Programmatic);
				return;
			}

			if(title.Text == "Metric to Imperial")
			{
				press = press * 0.14503;
			}
			else if(title.Text == "Imperial to Metric")
			{
				press = press / 0.14503;
			}
			outputTextBox.Text = Math.Round(press,4).ToString();
		}

		private void switchButton_Click(object sender, RoutedEventArgs e)
		{
			if(title.Text == "Metric to Imperial")
			{
				title.Text = "Imperial to Metric";
			}
			else if(title.Text == "Imperial to Metric")
			{
				title.Text = "Metric to Imperial";
			}

		}
	}
}
