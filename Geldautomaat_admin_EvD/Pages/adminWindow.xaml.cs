using Geldautomaat_admin_EvD.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.RightsManagement;
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
using System.Collections.ObjectModel;

namespace Geldautomaat_admin_EvD.Pages
{
	/// <summary>
	/// Interaction logic for adminWindow.xaml
	/// </summary>
	public partial class adminWindow : Page
	{
		private Controllers.geldautomaat_controller klantObject;
		private rekeningen selectedRekening;
		private klanten selectedKlant;
		private admins _admin;
		public adminWindow(admins admin)
		{
			InitializeComponent();
			_admin = admin;
			klantObject = new Controllers.geldautomaat_controller();
			RekeningInfo rekeningInfo = new RekeningInfo();
			this.DataContext = rekeningInfo;

			this.IsVisibleChanged += (object sender, DependencyPropertyChangedEventArgs e) =>
			{
				Debug.WriteLine("Visible changed");
				klantObject = new Controllers.geldautomaat_controller();
				ObservableCollection<RekeningInfo> rekeningInfoList = new ObservableCollection<RekeningInfo>();

				var allRekeningen = klantObject.Klanten
				.SelectMany(klant => klant.rekening.Where(rekening => rekening.klanten_Klantnummer == klant.Klantnummer));

				foreach (var rekening in allRekeningen.Distinct())
				{
					// Find the corresponding klant for the current rekening
					var klant = klantObject.Klanten.FirstOrDefault(k => k.Klantnummer == rekening.klanten_Klantnummer);

					// Check if a corresponding klant is found
					if (klant != null)
					{
						// Create a new RekeningInfo object and add it to the collection
						RekeningInfo info = new RekeningInfo
						{
							Rekeningnummer = rekening.Rekeningnummer,
							KlantVoornaam = klant.Voornaam,
							Geblockt = rekening.Geblockt
						};

						// Add the RekeningInfo object to the collection
						rekeningInfoList.Add(info);
					}
				}

				rekeningListBox.ItemsSource = rekeningInfoList.Where(info => !info.Geblockt);
				rekeningListBoxBlocked.ItemsSource = rekeningInfoList.Where(info => info.Geblockt);
			};

			// Create a list to hold RekeningInfo objects
			ObservableCollection<RekeningInfo> rekeningInfoList = new ObservableCollection<RekeningInfo>();

			// Populate the list with data
			var allRekeningen = klantObject.Klanten
				.SelectMany(klant => klant.rekening.Where(rekening => rekening.klanten_Klantnummer == klant.Klantnummer));

			foreach (var rekening in allRekeningen.Distinct())
			{
				// Find the corresponding klant for the current rekening
				var klant = klantObject.Klanten.FirstOrDefault(k => k.Klantnummer == rekening.klanten_Klantnummer);

				// Check if a corresponding klant is found
				if (klant != null)
				{
					// Create a new RekeningInfo object and add it to the collection
					RekeningInfo info = new RekeningInfo
					{
						Rekeningnummer = rekening.Rekeningnummer,
						KlantVoornaam = klant.Voornaam,
						Geblockt = rekening.Geblockt
					};

					// Add the RekeningInfo object to the collection
					rekeningInfoList.Add(info);
				}
			}

			// Bind the collection to the ItemsSource property of your ListBox controls
			rekeningListBox.ItemsSource = rekeningInfoList.Where(info => !info.Geblockt);
			rekeningListBoxBlocked.ItemsSource = rekeningInfoList.Where(info => info.Geblockt);

			adminLabel.Content = $"Goedendag: {_admin.Gebruikersnaam}";
		}

		public class RekeningInfo : INotifyPropertyChanged
		{
			private string _rekeningnummer;
			private string _klantVoornaam;
			private bool _geblockt;
				
			public string Rekeningnummer
			{
				get { return _rekeningnummer; }
				set
				{
					if (_rekeningnummer != value)
					{
						_rekeningnummer = value;
						OnPropertyChanged(nameof(Rekeningnummer));
					}
				}
			}

			public string KlantVoornaam
			{
				get { return _klantVoornaam; }
				set
				{
					if (_klantVoornaam != value)
					{
						_klantVoornaam = value;
						OnPropertyChanged(nameof(KlantVoornaam));
					}
				}
			}

			public bool Geblockt
			{
				get { return _geblockt; }
				set
				{
					if (_geblockt != value)
					{
						_geblockt = value;
						OnPropertyChanged(nameof(Geblockt));
					}
				}
			}

			public event PropertyChangedEventHandler PropertyChanged;

			protected virtual void OnPropertyChanged(string propertyName)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			List<RekeningInfo> rekeningInfoList = new List<RekeningInfo>();
			string searchText = searchBox.Text.ToLower();
			rekeningInfoList.Clear();
			foreach (var klant in klantObject.Klanten)
			{
				foreach (var rekening in klant.rekening)
				{
					if (rekening.Geblockt == false)
					{
						if (rekening.Rekeningnummer.ToLower().Contains(searchText) && rekening.klanten_Klantnummer == klant.Klantnummer ||
							klant.Achternaam.ToLower().Contains(searchText) && rekening.klanten_Klantnummer == klant.Klantnummer)
						{
							RekeningInfo info = new RekeningInfo
							{
								Rekeningnummer = rekening.Rekeningnummer,
								KlantVoornaam = klant.Voornaam
							};
							rekeningInfoList.Add(info);
						}
					}
				}
			}
			rekeningListBox.ItemsSource = rekeningInfoList;
		}


		private void rekeningListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Check if an item is selected
			if (rekeningListBox.SelectedItem != null)
			{
				// Retrieve the selected RekeningInfo object
				RekeningInfo selectedRekeningInfo = rekeningListBox.SelectedItem as RekeningInfo;

				if (selectedRekeningInfo != null)
				{
					// Extract rekeningnummer portion
					string selectedRekeningnummer = selectedRekeningInfo.Rekeningnummer;

					// Find the corresponding Rekening object and its associated Klant
					selectedRekening = klantObject.Klanten
						.SelectMany(klant => klant.rekening)
						.FirstOrDefault(rekening => rekening.Rekeningnummer == selectedRekeningnummer);

					if (selectedRekening != null)
					{
						selectedKlant = klantObject.Klanten
							.FirstOrDefault(k => k.Klantnummer == selectedRekening.klanten_Klantnummer);

						if (selectedKlant != null)
						{
							Debug.WriteLine($"Selected rekeningnummer: {selectedRekening.Rekeningnummer}");
							Debug.WriteLine($"Selected klant: {selectedKlant.Voornaam} {selectedKlant.Achternaam}");
							return;
						}
					}
				}

				Debug.WriteLine("Selected Rekening or Klant is null.");
			}
		}


		private void SearchBoxBlocked_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			List<RekeningInfo> rekeningInfoList = new List<RekeningInfo>();
			string searchText = searchBoxBlocked.Text.ToLower();
			rekeningInfoList.Clear();
			foreach (var klant in klantObject.Klanten)
			{
				foreach (var rekening in klant.rekening)
				{
					if (rekening.Geblockt == true)
					{
						if (rekening.Rekeningnummer.ToLower().Contains(searchText) && rekening.klanten_Klantnummer == klant.Klantnummer ||
							klant.Achternaam.ToLower().Contains(searchText) && rekening.klanten_Klantnummer == klant.Klantnummer)
						{
							RekeningInfo info = new RekeningInfo
							{
								Rekeningnummer = rekening.Rekeningnummer,
								KlantVoornaam = klant.Voornaam
							};
							rekeningInfoList.Add(info);
						}
					}
				}
			}
		}

		private void rekeningListBoxBlocked_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (rekeningListBoxBlocked.SelectedItem != null)
			{
				// Retrieve the selected RekeningInfo object
				RekeningInfo selectedRekeningInfo = rekeningListBoxBlocked.SelectedItem as RekeningInfo;

				if (selectedRekeningInfo != null)
				{
					// Extract rekeningnummer portion
					string selectedRekeningnummer = selectedRekeningInfo.Rekeningnummer;

					selectedRekening = klantObject.Klanten
						.SelectMany(klant => klant.rekening)
						.FirstOrDefault(rekening => rekening.Rekeningnummer == selectedRekeningnummer);

					if (selectedRekening != null)
					{
						selectedKlant = klantObject.Klanten
							.FirstOrDefault(k => k.Klantnummer == selectedRekening.klanten_Klantnummer);

						if (selectedKlant != null)
						{
							Debug.WriteLine($"Selected rekeningnummer: {selectedRekening.Rekeningnummer}");
							Debug.WriteLine($"Selected klant: {selectedKlant.Voornaam} {selectedKlant.Achternaam}");
							return;
						}
					}
				}

				Debug.WriteLine("Selected Rekening or Klant is null.");
			}
		}

		private void addRekening_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				addAccount addAccountPage = new addAccount();
				mainWindow.MainAdminFrame.Visibility = Visibility.Collapsed;
				mainWindow.addAccountFrame.Visibility = Visibility.Visible;

				mainWindow.addAccountFrame.Navigate(addAccountPage);
			}
		}

		private void klantBtn_Click(object sender, RoutedEventArgs e)
		{
			if (selectedKlant != null)
			{
				MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
				if (mainWindow != null)
				{
					editUser editUserPage = new editUser(selectedKlant);
					mainWindow.MainAdminFrame.Visibility = Visibility.Collapsed;
					mainWindow.editUserFrame.Visibility = Visibility.Visible;

					mainWindow.editUserFrame.Navigate(editUserPage);
				}
			} 
			else
			{
				MessageBox.Show("Selecteer eerst een klant");
			}
		}

		private void rekeningBtn_Click(object sender, RoutedEventArgs e)
		{
			if (selectedRekening != null)
			{
				MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
				if (mainWindow != null)
				{
					editAccount editAccountPage = new editAccount(selectedRekening);
					mainWindow.MainAdminFrame.Visibility = Visibility.Collapsed;
					mainWindow.editAccountFrame.Visibility = Visibility.Visible;

					mainWindow.editAccountFrame.Navigate(editAccountPage);
				}
			} 
			else
			{
				MessageBox.Show("Selecteer eerst een rekening");
			}
		}

		#region Depricated
		//private void blockRekening_Click(object sender, RoutedEventArgs e)
		//{
		//	if (rekeningListBox.SelectedItem != null)
		//	{
		//		// Retrieve the selected RekeningInfo object
		//		RekeningInfo selectedRekeningInfo = rekeningListBox.SelectedItem as RekeningInfo;

		//		if (selectedRekeningInfo != null)
		//		{
		//			// Extract rekeningnummer portion
		//			string selectedRekeningnummer = selectedRekeningInfo.Rekeningnummer;

		//			// Find the corresponding Rekening object and its associated Klant
		//			rekeningen selectedRekening = klantObject.Klanten
		//				.SelectMany(klant => klant.rekening)
		//				.FirstOrDefault(rekening => rekening.Rekeningnummer == selectedRekeningnummer);

		//			if (selectedRekening != null)
		//			{
		//				// Update the Geblockt property
		//				selectedRekeningInfo.Geblockt = true; // Assuming Geblockt is a boolean property

		//				// Execute SQL to update the database
		//				string query = "UPDATE rekeningen SET Geblockt = 1 WHERE Rekeningnummer = @rekeningnummer";
		//				using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
		//				{
		//					cmd.Parameters.AddWithValue("@rekeningnummer", selectedRekening.Rekeningnummer);
		//					cmd.ExecuteNonQuery();
		//					MessageBox.Show("U heeft succesvol de rekening geblockt");
		//				}
		//			}
		//		}
		//	}
		//	else if (rekeningListBoxBlocked.SelectedItem != null)
		//	{
		//		// Retrieve the selected RekeningInfo object
		//		RekeningInfo selectedRekeningInfo = rekeningListBoxBlocked.SelectedItem as RekeningInfo;

		//		if (selectedRekeningInfo != null)
		//		{
		//			// Extract rekeningnummer portion
		//			string selectedRekeningnummer = selectedRekeningInfo.Rekeningnummer;

		//			// Find the corresponding Rekening object and its associated Klant
		//			rekeningen selectedRekening = klantObject.Klanten
		//				.SelectMany(klant => klant.rekening)
		//				.FirstOrDefault(rekening => rekening.Rekeningnummer == selectedRekeningnummer);

		//			if (selectedRekening != null)
		//			{
		//				// Update the Geblockt property
		//				selectedRekeningInfo.Geblockt = false; // Assuming Geblockt is a boolean property

		//				// Execute SQL to update the database
		//				string query = "UPDATE rekeningen SET Geblockt = 0 WHERE Rekeningnummer = @rekeningnummer";
		//				using (MySqlCommand cmd = new MySqlCommand(query, Controllers.geldautomaat_controller.Connection))
		//				{
		//					cmd.Parameters.AddWithValue("@rekeningnummer", selectedRekening.Rekeningnummer);
		//					cmd.ExecuteNonQuery();
		//					MessageBox.Show("U heeft succesvol de rekening gedeblokkeert");
		//				}
		//			}
		//		}
		//	}
		//}

		#endregion

		private void logOut_click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				MainWindow login = new MainWindow();
				login.Show();
				mainWindow.Close();

			}
		}
	}
}