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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
		rekeningen transactieObject;
		public Page3(rekeningen rekeningObject)
        {
			InitializeComponent();
			transactieObject = rekeningObject;
			this.DataContext = transactieObject;
		}

		private void storten_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				geldStorten withdrawAmountPage = new geldStorten(transactieObject);
				mainWindow.withdrawFrame.Visibility = Visibility.Collapsed;
				mainWindow.withdrawAmountFrame.Visibility = Visibility.Visible;

				mainWindow.withdrawAmountFrame.Navigate(withdrawAmountPage);
			}
		}

		private void stortenHandelen(Button button)
		{
			decimal bedrag = decimal.Parse(button.Tag.ToString());

			var depositTransaction = new transacties
			{
				Bedrag = bedrag,
				rekeningen_Rekeningnummer = transactieObject.Rekeningnummer,
				Soort = "Storting",
				Datum_en_tijd = DateTime.Now
			};

			transactieObject.Saldo += bedrag;

			string query = "UPDATE rekeningen SET saldo = saldo + @bedrag WHERE rekeningnummer = @rekeningnummer";
			using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@bedrag", bedrag);
				cmd.Parameters.AddWithValue("@rekeningnummer", transactieObject.Rekeningnummer);
				cmd.ExecuteNonQuery();
			}

			string query2 = "INSERT INTO transacties (Bedrag, rekeningen_rekeningnummer, Soort) VALUES (@bedrag, @rekeningnummer, @Soort)";
			using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@bedrag", bedrag);
				cmd.Parameters.AddWithValue("@rekeningnummer", transactieObject.Rekeningnummer);
				cmd.Parameters.AddWithValue("@Soort", depositTransaction.Soort);
				cmd.ExecuteNonQuery();
			}
			transactieObject.Transacties.Add(depositTransaction);
		}


		private void storten5_Click(object sender, RoutedEventArgs e)
		{
			stortenHandelen((Button)sender);
			MessageBox.Show("U heeft 5 euro gestort");
		}

		private void storten10_Click(object sender, RoutedEventArgs e)
		{
			stortenHandelen((Button)sender);
			MessageBox.Show("U heeft 10 euro gestort");
		}

		private void storten20_Click(object sender, RoutedEventArgs e)
		{
			stortenHandelen((Button)sender);
			MessageBox.Show("U heeft 20 euro gestort");
		}

		private void storten50_Click(object sender, RoutedEventArgs e)
		{
			stortenHandelen((Button)sender);
			MessageBox.Show("U heeft 50 euro gestort");
		}

		private void storten100_Click(object sender, RoutedEventArgs e)
		{
			stortenHandelen((Button)sender);
			MessageBox.Show("U heeft 100 euro gestort");
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.MainFrame.Visibility = Visibility.Visible;
				mainWindow.depositFrame.Visibility = Visibility.Collapsed;
			}
		}
	}
}
