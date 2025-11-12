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
	public sealed partial class CurrencyConvertor : Page
	{

		// Conversion rates for maths
		private readonly Dictionary<string, Dictionary<string, double>> conversionRates =
			new Dictionary<string, Dictionary<string, double>>()
		{
			{ "USD", new Dictionary<string, double>
				{
				{"USD", 1},
				{"EUR", 0.85189982 },
				{"GBP",  0.72872436},
				{"INR",  74.257327},
				}
			},

			{ "EUR", new Dictionary<string, double>
				{
				{"USD", 1.1739732 },
				{"EUR", 1},
				{"GBP", 0.8556672 },
				{"INR", 87.00755 }
				}
			},

				{	"GBP", new Dictionary<string, double>
					{
					{"USD", 1.371907},
					{"EUR", 1.1686692},
					{"GBP", 1 },
					{"INR", 101.68635 }
					}
				},
			{ "INR", new Dictionary<string, double>
				{
				{"USD", 0.011492628},
				{"EUR", 0.013492774},
				{"GBP", 0.0098339397},
				{"INR", 1 }
				}
			}

		};


		public CurrencyConvertor()
		{
			this.InitializeComponent();
		}

		private void AmountInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			string amount = AmountInput.Text;


			if (amount == "")
			{
				amount = "100";
			}

			CurrencyAmount.Text = amount;
		}


		private async void CalculateCurrencyButton_Click(object sender, RoutedEventArgs e)
		{

			if (CurrencyType == null || ConversionRateForwards == null || FromCurrencyComboBox.SelectedItem == null)
				return;

			string input = AmountInput.Text.Trim();

			if (string.IsNullOrEmpty(input) || !double.TryParse(input, out double amount))
			{
				var dialog = new MessageDialog("Amount must be a valid number");
				await dialog.ShowAsync();
				return; // stop execution if input is invalid
			}

			if (toCurrencyComboBox?.SelectedItem is ComboBoxItem toItem &&
				FromCurrencyComboBox.SelectedItem is ComboBoxItem fromItem) 
			{
				string fromCurrency = fromItem.Tag?.ToString();
				string toCurrency = toItem.Tag?.ToString();

				CurrencyType.Text = fromCurrency + " = ";

				// conversion rate from dictionary
				double rateForwards = conversionRates[fromCurrency][toCurrency];
				double rateBackwards  = conversionRates[toCurrency][fromCurrency];
				double conversionSum = conversionRates[fromCurrency][toCurrency] * amount;


				// Update textblocks to conversion rate
				ConversionRateForwards.Text = $"1 {fromCurrency} = {rateForwards:F6} {toCurrency}";
				ConversionRateBackwards.Text = $"1 {toCurrency} = {rateBackwards:f6} {fromCurrency}";
				CurrencyConversionSum.Text = $"{conversionSum} {toCurrency}";
			}
		}
	}

}
