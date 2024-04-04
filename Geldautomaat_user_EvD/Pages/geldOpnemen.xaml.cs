using Geldautomaat_EvD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Geldautomaat_EvD.Controllers;

namespace Geldautomaat_EvD.Pages
{
    /// <summary>
    /// Interaction logic for geldOpnemen.xaml
    /// </summary>
    public partial class geldOpnemen : Page
    {
		rekeningen opnemenObject;
		public geldOpnemen(rekeningen transactieObject)
		{
			InitializeComponent();
			opnemenObject = transactieObject;
			this.DataContext = transactieObject;

		}

		public bool CanMakeTransactionToday(string rekeningnummer)
		{
			DateTime currentDate = DateTime.Today;

			string query3 = "SELECT COUNT(*) FROM transacties WHERE rekeningen_rekeningnummer = @rekeningnummer AND DATE(Datum_en_tijd) = @currentDate AND Soort = 'Opname'";
			using (MySqlCommand command = new MySqlCommand(query3, Controllers.geldautomaat_controller.Connection))
			{
				command.Parameters.AddWithValue("@rekeningnummer", rekeningnummer);
				command.Parameters.AddWithValue("@currentDate", currentDate);

				int transactionCount = Convert.ToInt32(command.ExecuteScalar());

				return transactionCount < 3;
			}
		}

		public bool CanMakeTransactionAmountToday(string rekeningnummer, decimal amount)
		{
			DateTime currentDate = DateTime.Today;

			string totalAmountQuery = "SELECT SUM(Bedrag) FROM transacties WHERE rekeningen_rekeningnummer = @rekeningnummer AND DATE(Datum_en_tijd) = @currentDate AND Soort = 'Opname'";
			using (MySqlCommand amountCommand = new MySqlCommand(totalAmountQuery, Controllers.geldautomaat_controller.Connection))
			{
				amountCommand.Parameters.AddWithValue("@rekeningnummer", rekeningnummer);
				amountCommand.Parameters.AddWithValue("@currentDate", currentDate);

				object sumResult = amountCommand.ExecuteScalar();
				decimal totalAmountToday = sumResult != DBNull.Value ? Convert.ToDecimal(sumResult) : 0;

				return totalAmountToday + amount <= 1500;
			}
		}

		private void opnemen_Submit(object sender, RoutedEventArgs e)
		{
			if (opnemenObject.Saldo > 0)
			{
				decimal bedrag;
				if (!decimal.TryParse(saldoToevoeging.Text, out bedrag))
				{
					MessageBox.Show("Ongeldige invoer voor het bedrag.");
					return;
				}

				var withdrawTransaction = new transacties
				{
					Bedrag = bedrag,
					rekeningen_Rekeningnummer = opnemenObject.Rekeningnummer,
					Soort = "Opname",
					Datum_en_tijd = DateTime.Now
				};
				if (opnemenObject.Saldo > decimal.Parse(saldoToevoeging.Text))
				{
					if (CanMakeTransactionAmountToday(opnemenObject.Rekeningnummer, decimal.Parse(saldoToevoeging.Text)))
					{
						if (CanMakeTransactionToday(opnemenObject.Rekeningnummer))
						{
							int maxAmount = 500;
							if (Convert.ToInt32(saldoToevoeging.Text) <= maxAmount)
							{
								opnemenObject.Saldo -= decimal.Parse(saldoToevoeging.Text);
								string query = "UPDATE rekeningen SET saldo = @saldo WHERE rekeningnummer = @rekeningnummer";
								using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
								{
									cmd.Parameters.AddWithValue("@saldo", opnemenObject.Saldo);
									cmd.Parameters.AddWithValue("@rekeningnummer", opnemenObject.Rekeningnummer);
									cmd.ExecuteNonQuery();
								}
								var opname = "Opname";
								string query2 = "INSERT INTO transacties (Bedrag, rekeningen_rekeningnummer, Soort) VALUES (@bedrag, @rekeningnummer, @Soort)";
								using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
								{
									decimal bedragen = decimal.Parse(saldoToevoeging.Text) * -1;
									cmd.Parameters.AddWithValue("@bedrag", bedragen);
									cmd.Parameters.AddWithValue("@rekeningnummer", opnemenObject.Rekeningnummer);
									cmd.Parameters.AddWithValue("@Soort", opname);
									cmd.ExecuteNonQuery();
								}

								opnemenObject.Transacties.Add(withdrawTransaction);

								MessageBox.Show("U heeft succesvol geld opgenomen");
							}
							else
							{
								MessageBox.Show("U kunt maximaal 500 euro opnemen");
							}
						}
						else
						{
							MessageBox.Show("U heeft vandaag al drie transacties gedaan");
						}
					}
					else
					{
						MessageBox.Show("U heeft uw limiet van 1500 euro al bereikt");
					}
				}
				else
				{
					MessageBox.Show("U heeft niet genoeg saldo om geld op te nemen");

				}
			}
			else
			{
				MessageBox.Show("U heeft niet genoeg saldo om geld op te nemen");
			}

		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.depositAmountFrame.Visibility = Visibility.Collapsed;
				mainWindow.withdrawFrame.Visibility = Visibility.Visible;
			}
		}
	}
}