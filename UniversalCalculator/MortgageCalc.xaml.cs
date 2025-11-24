using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class MortgageCalc : Page
	{
		public MortgageCalc()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double P = double.Parse(principalBorrowedTextBox.Text);
				double annualRate = double.Parse(annualInterestRateTextBox.Text) / 100;
				int years = int.Parse(yearsTextBox.Text);
				int months = int.Parse(monthsTextBox.Text);

				double i = annualRate / 12;
				int n = (years * 12) + months;

				double M = P * (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1);

				monthlyInteresetRateTextBox.Text = i.ToString("F4");
				monthlyRepaymentTextBox.Text = M.ToString("F2");

			}

			catch
			{
				monthlyRepaymentTextBox.Text = "Invalid input!";
			}

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));

		}
	}
}
