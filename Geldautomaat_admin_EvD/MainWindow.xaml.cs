using Geldautomaat_admin_EvD.Models;
using Geldautomaat_admin_EvD;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geldautomaat_admin_EvD.Pages;

namespace Geldautomaat_admin_EvD
{
	public partial class MainWindow : Window
	{
		Controllers.geldautomaat_controller geldautomaatObject;

		public MainWindow()
		{
			InitializeComponent();
			geldautomaatObject = new Controllers.geldautomaat_controller();
			Debug.WriteLine(geldautomaatObject.getAdmins().Count());
			this.DataContext = geldautomaatObject;
		}
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			if (textBoxEmail.Text.Length == 0)
			{
				errormessage.Text = "Voer uw pas in";
				textBoxEmail.Focus();
				return;
			}

			string email = textBoxEmail.Text;
			string password = passwordBox1.Password;

			LoginResult rekeningResult = activeRekening(email, password);
			LoginResult adminResult = activeAdmin(email, password);

			if (adminResult.IsSuccessful)
			{
				MessageBox.Show("Admin Login Success");

				admins admin = geldautomaatObject.Admins.FirstOrDefault(a => a.Admin_ID == adminResult.AdminID);

				if (admin != null)
				{
					LoginGrid.Visibility = Visibility.Collapsed;
					MainAdminFrame.Visibility = Visibility.Visible;
					adminWindow adminPage = new adminWindow(admin);
					MainAdminFrame.Navigate(adminPage);
				}
				else
				{
					MessageBox.Show("Admins object not found!");
				}
			}
			else
			{
				errormessage.Text = "Ongeldige pas";
			}
		}

		public class LoginResult
		{
			public bool IsSuccessful { get; set; }
			public int KlantID { get; set; }
			public rekeningen RekeningObject { get; set; }
			public int AdminID { get; set; }

			public LoginResult(bool isSuccessful, int klantID, rekeningen rekeningObject, int adminID)
			{
				IsSuccessful = isSuccessful;
				KlantID = klantID;
				RekeningObject = rekeningObject;
				AdminID = adminID;
			}
		}

		public LoginResult activeRekening(string rekeningNummer, string pincode)
		{
			foreach (klanten kl in geldautomaatObject.Klanten)
			{
				foreach (rekeningen rek in kl.rekening)
				{
					if (rek.Rekeningnummer == rekeningNummer)
					{
						Debug.WriteLine($"Rekeningnummer gevonden op {rek.Rekeningnummer}");
						var klantNummer = geldautomaatObject.Klanten.Find(x => x.Klantnummer == rek.klanten_Klantnummer);
						if (klantNummer != null)
						{
							int klantID = klantNummer.Klantnummer;
							foreach (rekeningen rekening in klantNummer.rekening)
							{
								if (rekening != null && rekening.Pincode.ToString() == pincode)
								{
									foreach (transacties transac in rek.Transacties)
									{
										Debug.WriteLine($"Transactie gevonden op {transac.Transactie_ID}");
									}
									Debug.WriteLine(klantID);
									return new LoginResult(true, klantID, rek, 0);
								}

							}
						}
					}
				}
			}
			return new LoginResult(false, 0, null, 0);
		}

		public LoginResult activeAdmin(string email, string password)
		{
			int adminID;
			admins admin = geldautomaatObject.Admins.FirstOrDefault(a => a.Gebruikersnaam == email);

			if (admin != null)
			{
				adminID = admin.Admin_ID;
				if (admin.Wachtwoord == password)
				{
					return new LoginResult(true, 0, null, adminID);
				}
			}
			return new LoginResult(false, 0, null, 0);
		}
	}
}