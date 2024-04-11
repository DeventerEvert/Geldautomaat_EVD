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

	public partial class editAccount : Page
	{
		private rekeningen rekeningObject;
		public editAccount(rekeningen rekeningObject)
		{
			InitializeComponent();
			this.DataContext = rekeningObject;
			idLbl.Content = rekeningObject.klanten_Klantnummer;
			rekeningTxt.Text = rekeningObject.Rekeningnummer;
			this.rekeningObject = rekeningObject;

		}

		private void generatePinBtn_Click(object sender, RoutedEventArgs e)
		{
			Random random = new Random();
			int pin = random.Next(1000, 10000);
			pinDisplay.Content = pin;
		}

		private void submitBtn_Click(object sender, RoutedEventArgs e)
		{
			string pincode = pinDisplay.Content?.ToString(); 

			if (pincode != null) 
			{
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

				string query = "UPDATE rekeningen SET rekeningNummer = @rekeningNmr, Pincode = @pincode, Geblockt = @Geblockt WHERE klanten_Klantnummer = @id";
				using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
				{
					cmd.Parameters.AddWithValue("@rekeningNmr", rekeningTxt.Text);
					cmd.Parameters.AddWithValue("@pincode", pincodeHashed);
					cmd.Parameters.AddWithValue("@id", idLbl.Content);
					cmd.Parameters.AddWithValue("@Geblockt", bannedCheckbox.IsChecked);

					cmd.ExecuteNonQuery();
					MessageBox.Show("U heeft succesvol de rekening verandert");
				}
			}
			else
			{
				string query = "UPDATE rekeningen SET rekeningNummer = @rekeningNmr, Geblockt = @Geblockt WHERE klanten_Klantnummer = @id";
				using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
				{
					cmd.Parameters.AddWithValue("@rekeningNmr", rekeningTxt.Text);
					cmd.Parameters.AddWithValue("@id", idLbl.Content);
					cmd.Parameters.AddWithValue("@Geblockt", bannedCheckbox.IsChecked);

					cmd.ExecuteNonQuery();
					MessageBox.Show("U heeft succesvol de rekening verandert");
				}
			}
		}

		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.editAccountFrame.Visibility = Visibility.Collapsed;
				mainWindow.MainAdminFrame.Visibility = Visibility.Visible;
			}
		}
	}
}