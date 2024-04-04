using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Geldautomaat_EvD.Models;
using MySqlConnector;



namespace Geldautomaat_EvD.Controllers
{
	public class geldautomaat_controller : SQL, INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		public geldautomaat_controller()
		{
			_klanten = getKlanten();
			_admins = getAdmins();
		}

		#region rekeningen
		private List<rekeningen> getRekeningen(int klanten_Klantnummer)
		{
			List<rekeningen> _rekeningen = new List<rekeningen>();
			string query = "SELECT * FROM rekeningen";
			using (MySqlCommand cmd = new MySqlCommand(query, Connection))
			{
				cmd.Parameters.AddWithValue("@klanten_Klantnummer", klanten_Klantnummer);
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{

					rekeningen getRekening = new rekeningen
						(
						reader.GetString(0),
							reader.GetString(1),
							reader.GetDecimal(2),
							reader.GetBoolean(3),
							reader.GetInt32(4)
						);
					//getRekening.Rekeningnummer = reader.GetString(0);
					//getRekening.Pincode = reader.GetString(1);
					//getRekening.Saldo = reader.GetDecimal(2);
					//getRekening.Geblockt = reader.GetBoolean(3);
					//getRekening.klanten_Klantnummer = reader.GetInt32(4);
					//getRekening.Transacties = getTransacties(getRekening.Rekeningnummer);
					_rekeningen.Add(getRekening);
				}

				reader.Close();
				reader.Dispose();
			}
			foreach (rekeningen getRekening in _rekeningen)
			{
				try { getRekening.Transacties = getTransacties(getRekening.Rekeningnummer); }
				catch
				{
					// dit nog ff afhandelen, pik
				}
			}
			return _rekeningen;
		}
		#endregion

		#region transacties
		private List<transacties> getTransacties(string Rekeningnummer)
		{
			List<transacties> _transacties = new List<transacties>();
			string query = "SELECT * FROM transacties WHERE rekeningen_Rekeningnummer = @Rekeningnummer";
			using (MySqlCommand cmd = new MySqlCommand(query, Connection))
			{

				cmd.Parameters.AddWithValue("@Rekeningnummer", Rekeningnummer);
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					transacties getTransactie = new transacties();
					getTransactie.Transactie_ID = reader.GetInt32(0);
					getTransactie.rekeningen_Rekeningnummer = reader.GetString(1);
					getTransactie.Datum_en_tijd = reader.GetDateTime(2);
					getTransactie.Bedrag = reader.GetDecimal(3);
					getTransactie.Soort = reader.GetString(4);
					_transacties.Add(getTransactie);
				}
				reader.Close();
				reader.Dispose();
			}
			return _transacties;
		}
		#endregion

		#region admins
		public List<admins> getAdmins()
		{
			List<admins> _admins = new List<admins>();
			string query = "SELECT * FROM admins";
			using (MySqlCommand cmd = new MySqlCommand(query, Connection))
			{
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					admins getAdmin = new admins();
					getAdmin.Admin_ID = reader.GetInt32(0);
					getAdmin.Gebruikersnaam = reader.GetString(1);
					getAdmin.Wachtwoord = reader.GetString(2);
					_admins.Add(getAdmin);
				}

				reader.Close();
				reader.Dispose();

			}
			return _admins;
		}
		#endregion

		#region klanten
		private List<klanten> getKlanten()
		{
			List<klanten> _klanten = new List<klanten>();
			string query = "SELECT * FROM klanten";
			using (MySqlCommand cmd = new MySqlCommand(query, Connection))
			{
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					klanten getKlant = new klanten();
					getKlant.Klantnummer = reader.GetInt32(0);
					getKlant.Voornaam = reader.GetString(1);
					getKlant.Achternaam = reader.GetString(2);
					getKlant.Adres = reader.GetString(3);
					getKlant.Contactgegevens = reader.GetString(4);
					_klanten.Add(getKlant);
				}

				reader.Close();
				reader.Dispose();
			}
			foreach (klanten getKlant in _klanten)
			{
				getKlant.rekening = getRekeningen(getKlant.Klantnummer);
			}
			return _klanten;
		}
		#endregion
		private List<klanten> _klanten = new List<klanten>();
		public List<klanten> Klanten
		{
			get { return _klanten; }
			set
			{
				_klanten = value;
				OnPropertyChanged();
			}
		}

		// Admins related properties
		private List<admins> _admins = new List<admins>();
		public List<admins> Admins
		{
			get { return _admins; }
			set
			{
				_admins = value;
				OnPropertyChanged();
			}
		}

		// Active Klant related property
		private klanten _activeKlant;
		public klanten ActiveKlant
		{
			get { return _activeKlant; }
			set
			{
				_activeKlant = value;
				OnPropertyChanged();
				if (value != null)
				{
					_activeKlant.rekening = getRekeningen(Convert.ToInt32(value.Klantnummer));
					OnPropertyChanged(nameof(ActiveKlant));
				}
			}
		}

		// Active Rekening related property
		private rekeningen _activeRekening;
		public rekeningen ActiveRekening
		{
			get { return _activeRekening; }
			set
			{
				_activeRekening = value;
				OnPropertyChanged();
			}
		}

		public rekeningen activeRekening
		{
			get { return _activeRekening; }
			set
			{
				_activeRekening = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("activeRekening"));
			}
		}

		public int MyProperty { get; set; }

		public void DoNotifyPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void NotifyPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
