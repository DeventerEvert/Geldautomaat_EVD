using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomaat_admin_EvD.Models
{
	public class klanten : INotifyPropertyChanged
	{
		private int _klantnummer;
		private string _voornaam;
		private string _achternaam;
		private string _adres;
		private string _contactgegevens;
		private List<rekeningen> _rekening;

		public int Klantnummer
		{
			get { return _klantnummer; }
			set { _klantnummer = value; OnPropertyChanged(); }
		}

		public string Voornaam
		{
			get { return _voornaam; }
			set { _voornaam = value; OnPropertyChanged(); }
		}

		public string Achternaam
		{
			get { return _achternaam; }
			set { _achternaam = value; OnPropertyChanged(); }
		}

		public string Adres
		{
			get { return _adres; }
			set { _adres = value; OnPropertyChanged(); }
		}

		public string Contactgegevens
		{
			get { return _contactgegevens; }
			set { _contactgegevens = value; OnPropertyChanged(); }
		}

		public List<rekeningen> rekening
		{
			get { return _rekening; }
			set { _rekening = value; OnPropertyChanged(); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
