using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Geldautomaat_EvD.Controllers;
using Geldautomaat_EvD.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Numerics;
using Geldautomaat_EvD.Pages;

namespace Geldautomaat_EvD
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>	
	public partial class MainWindow : Window
	{
		Controllers.geldautomaat_controller geldautomaatObject;

		public MainWindow()
		{
			InitializeComponent();
			geldautomaatObject = new Controllers.geldautomaat_controller();
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

			if (rekeningResult.IsSuccessful)
			{
				klanten klant = geldautomaatObject.Klanten.FirstOrDefault(k => k.Klantnummer == rekeningResult.KlantID);
				rekeningen rekening = klant.rekening.FirstOrDefault(r => r.klanten_Klantnummer == rekeningResult.KlantID);

				if (klant != null && rekening.Geblockt == false)
				{	
					LoginGrid.Visibility = Visibility.Collapsed;
					MainFrame.Visibility = Visibility.Visible;
					Page1 nextPage = new Page1(klant, rekening);
					MainFrame.Navigate(nextPage);

				}
				else
				{
					errormessage.Text = "Uw account is geblokkeerd, neem contact op";
				}
			}
			else
			{
				errormessage.Text = "Uw rekeningnummer of pincode is onjuist";
			}
		}

		public class LoginResult
		{
			public bool IsSuccessful { get; set; }
			public int KlantID { get; set; }
			public rekeningen RekeningObject { get; set; }


			public LoginResult(bool isSuccessful, int klantID, rekeningen rekeningObject, int adminID)
			{
				IsSuccessful = isSuccessful;
				KlantID = klantID;
				RekeningObject = rekeningObject;

			}
		}

		public LoginResult activeRekening(string rekeningNummer, string pincode)
		{
			string hashedPincode;
			using (SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pincode));
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				hashedPincode = builder.ToString();
			}

			foreach (klanten kl in geldautomaatObject.Klanten)
			{
				foreach (rekeningen rek in kl.rekening)
				{
					if (rek.Rekeningnummer == rekeningNummer)
					{
						klanten klantNummer = geldautomaatObject.Klanten.Find(x => x.Klantnummer == rek.klanten_Klantnummer);
						if (klantNummer != null)
						{
							foreach (rekeningen rekening in klantNummer.rekening)
							{
								if (rekening != null && rekening.Pincode == hashedPincode)
								{
									return new LoginResult(true, klantNummer.Klantnummer, rekening, 0);
								}
							}
						}
					}
				}
			}
			return new LoginResult(false, 0, null, 0);
		}
	}
}