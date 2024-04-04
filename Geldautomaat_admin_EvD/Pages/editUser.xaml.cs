using Geldautomaat_admin_EvD.Models;
using MySqlConnector;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace Geldautomaat_admin_EvD.Pages
{
	/// <summary>
	/// Interaction logic for editUser.xaml
	/// </summary>
	public partial class editUser : Page
	{
		public editUser(klanten klantObject)
		{
			InitializeComponent();
			this.DataContext = klantObject;
			idLbl.Content = klantObject.Klantnummer;

		}

		private void submitBtn_Click(object sender, RoutedEventArgs e)
		{
			string query2 = "UPDATE klanten SET Voornaam = @voornaam, Achternaam = @achternaam, Adres = @adres,Contactgegevens = @contact WHERE Klantnummer = @id";
			using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@voornaam", voornaamTxt.Text);
				cmd.Parameters.AddWithValue("@achternaam", achternaamTxt.Text);
				cmd.Parameters.AddWithValue("@adres", adresTxt.Text);
				cmd.Parameters.AddWithValue("@contact", contactTxt.Text);
				cmd.Parameters.AddWithValue("@id", idLbl.Content);
				cmd.ExecuteNonQuery();
				MessageBox.Show("U heeft succesvol de naam verandert");
			}
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.editUserFrame.Visibility = Visibility.Collapsed;
				mainWindow.MainAdminFrame.Visibility = Visibility.Visible;
			}
		}
	}
}
