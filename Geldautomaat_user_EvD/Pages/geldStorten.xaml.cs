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

namespace Geldautomaat_EvD.Pages
{
    /// <summary>
    /// Interaction logic for geldStorten.xaml
    /// </summary>
    public partial class geldStorten : Page
    {
		rekeningen stortenObject;
		public geldStorten(rekeningen transactieObject)
		{
			InitializeComponent();
			stortenObject = transactieObject;
			this.DataContext = transactieObject;
		}
		private void storten_Submit(object sender, RoutedEventArgs e)
		{
			decimal bedrag = decimal.Parse(saldoToevoeging.Text);
			var depositTransaction = new transacties
			{
				Bedrag = bedrag,
				rekeningen_Rekeningnummer = stortenObject.Rekeningnummer,
				Soort = "Storting",
				Datum_en_tijd = DateTime.Now 
			};

			stortenObject.Saldo += bedrag;

			string query = "UPDATE rekeningen SET saldo = saldo + @bedrag WHERE rekeningnummer = @rekeningnummer";
			using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@bedrag", bedrag);
				cmd.Parameters.AddWithValue("@rekeningnummer", stortenObject.Rekeningnummer);
				cmd.ExecuteNonQuery();
			}

			string query2 = "INSERT INTO transacties (Bedrag, rekeningen_rekeningnummer, Soort) VALUES (@bedrag, @rekeningnummer, @Soort)";
			using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@bedrag", bedrag);
				cmd.Parameters.AddWithValue("@rekeningnummer", stortenObject.Rekeningnummer);
				cmd.Parameters.AddWithValue("@Soort", depositTransaction.Soort);
				cmd.ExecuteNonQuery();
			}
				
			stortenObject.Transacties.Add(depositTransaction);
			MessageBox.Show("Bedrag is gestort!");
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.withdrawAmountFrame.Visibility = Visibility.Collapsed;
				mainWindow.depositFrame.Visibility = Visibility.Visible;
			}
		}
	}
}
