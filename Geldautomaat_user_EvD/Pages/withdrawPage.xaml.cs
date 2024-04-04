using Geldautomaat_EvD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySqlConnector;
using System.Diagnostics;
using System.Reflection;

namespace Geldautomaat_EvD.Pages
{
    /// <summary>
    /// Interaction logic for withdrawPage.xaml
    /// </summary>
    public partial class withdrawPage : Page
    {
		rekeningen transactieObject;
		public withdrawPage(rekeningen rekeningObject)
        {
            InitializeComponent();
			InitializeComponent();
			transactieObject = rekeningObject;
			this.DataContext = transactieObject;
		}

		public bool CanMakeTransactionToday(string rekeningnummer)
		{
			DateTime currentDate = DateTime.Today;
			Debug.WriteLine(rekeningnummer);

			string query3 = "SELECT COUNT(*) FROM transacties WHERE rekeningen_rekeningnummer = @rekeningnummer AND DATE(Datum_en_tijd) = @currentDate AND Soort = 'Opname'";
			using (MySqlCommand command = new MySqlCommand(query3, Controllers.geldautomaat_controller.Connection))
			{
				command.Parameters.AddWithValue("@rekeningnummer", rekeningnummer);
				command.Parameters.AddWithValue("@currentDate", currentDate);

				int transactionCount = Convert.ToInt32(command.ExecuteScalar());

				return transactionCount < 3;
			}
		}
		private void opnemenHandelen(Button button)
		{
			if (transactieObject.Saldo > 0)
			{
				if (CanMakeTransactionToday(transactieObject.Rekeningnummer))
				{
					decimal bedrag = decimal.Parse(button.Tag.ToString());

					var withdrawalTransaction = new transacties
					{
						Bedrag = -bedrag,
						rekeningen_Rekeningnummer = transactieObject.Rekeningnummer,
						Soort = "Opname",
						Datum_en_tijd = DateTime.Now
					};

					transactieObject.Saldo -= bedrag;

					string query = "UPDATE rekeningen SET saldo = saldo - @bedrag WHERE rekeningnummer = @rekeningnummer";
					using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
					{
						cmd.Parameters.AddWithValue("@bedrag", bedrag);
						cmd.Parameters.AddWithValue("@rekeningnummer", transactieObject.Rekeningnummer);
						cmd.ExecuteNonQuery();
					}

					string query2 = "INSERT INTO transacties (Bedrag, rekeningen_rekeningnummer, Soort) VALUES (@bedrag, @rekeningnummer, @Soort)";
					using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
					{
						cmd.Parameters.AddWithValue("@bedrag", -bedrag);
						cmd.Parameters.AddWithValue("@rekeningnummer", transactieObject.Rekeningnummer);
						cmd.Parameters.AddWithValue("@Soort", withdrawalTransaction.Soort);
						cmd.ExecuteNonQuery();
					}

					transactieObject.Transacties.Add(withdrawalTransaction);

				}
				else
				{
					MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
					return;
				}
			}
			else
			{
				MessageBox.Show("U heeft niet genoeg saldo om geld op te nemen");
			}
		}

		private void opnemen_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				geldOpnemen withdrawAmountPage = new geldOpnemen(transactieObject);
				mainWindow.depositFrame.Visibility = Visibility.Collapsed;
				mainWindow.depositAmountFrame.Visibility = Visibility.Visible;

				mainWindow.depositAmountFrame.Navigate(withdrawAmountPage);
			}
		}

		private void opnemen5_Click(object sender, RoutedEventArgs e)
		{
			if (!CanMakeTransactionToday(transactieObject.Rekeningnummer))
			{
				MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
				return;
			}
			opnemenHandelen((Button)sender);
			MessageBox.Show("U heeft 5 euro opgenomen");
		}

		private void opnemen10_Click(object sender, RoutedEventArgs e)
		{
			if (!CanMakeTransactionToday(transactieObject.Rekeningnummer))
			{
				MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
				return;
			}
			opnemenHandelen((Button)sender);
			MessageBox.Show("U heeft 10 euro opgenomen");
		}

		private void opnemen20_Click(object sender, RoutedEventArgs e)
		{
			if (!CanMakeTransactionToday(transactieObject.Rekeningnummer))
			{
				MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
				return;
			}
			opnemenHandelen((Button)sender);
			MessageBox.Show("U heeft 20 euro opgenomen");
		}

		private void opnemen50_Click(object sender, RoutedEventArgs e)
		{
			if (!CanMakeTransactionToday(transactieObject.Rekeningnummer))
			{
				MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
				return;
			}
			opnemenHandelen((Button)sender);
			MessageBox.Show("U heeft 50 euro opgenomen");
		}

		private void opnemen100_Click(object sender, RoutedEventArgs e)
		{
			if (!CanMakeTransactionToday(transactieObject.Rekeningnummer))
			{
				MessageBox.Show("U heeft uw limiet van 3 transacties behaald");
				return;
			}
			opnemenHandelen((Button)sender);
			MessageBox.Show("U heeft 100 euro opgenomen");
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.MainFrame.Visibility = Visibility.Visible;
				mainWindow.withdrawFrame.Visibility = Visibility.Collapsed;
			}
		}
	}
}
