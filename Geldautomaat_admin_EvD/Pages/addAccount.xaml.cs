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
	/// Interaction logic for addAccount.xaml
	/// </summary>
	public partial class addAccount : Page
	{
		public addAccount()
		{
			InitializeComponent();
		}

		private void addUser_Click(object sender, RoutedEventArgs e)
		{
			string rekeningnummer = addRekeningnummer.Text.ToString();
			string pincode = addPincode.Text.ToString();
			string voornaam = addVoornaam.Text.ToString();
			string achternaam = addAchternaam.Text.ToString();
			string adres = addAdres.Text.ToString();
			string contactgegevens = addContact.Text.ToString();

			string query = "INSERT INTO klanten (Voornaam, Achternaam, Adres, Contactgegevens) VALUES (@voornaam, @achternaam, @adres, @contactgegevens)";
			using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@voornaam", voornaam);
				cmd.Parameters.AddWithValue("@achternaam", achternaam);
				cmd.Parameters.AddWithValue("@adres", adres);
				cmd.Parameters.AddWithValue("@contactgegevens", contactgegevens);
				cmd.ExecuteNonQuery();
			}

			string pincodeHashed;
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pincode));
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				pincodeHashed = builder.ToString();
			}

			string query2 = "INSERT INTO rekeningen (Rekeningnummer, Pincode, saldo, klanten_Klantnummer) VALUES (@rekeningnummer, @pincode, @saldo, (SELECT MAX(Klantnummer) FROM klanten))";
			using (MySqlCommand cmd = new MySqlCommand(query2, Controllers.geldautomaat_controller.Connection))
			{
				cmd.Parameters.AddWithValue("@rekeningnummer", rekeningnummer);
				cmd.Parameters.AddWithValue("@pincode", pincodeHashed); // Use the hashed pincode
				cmd.Parameters.AddWithValue("@saldo", 1000);
				cmd.ExecuteNonQuery();
				MessageBox.Show("U heeft succesvol een rekening toegevoegd");
			}
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.addAccountFrame.Visibility = Visibility.Collapsed;
				mainWindow.MainAdminFrame.Visibility = Visibility.Visible;
			}
		}
	}
}