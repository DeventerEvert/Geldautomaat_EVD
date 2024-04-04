using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Geldautomaat_admin_EvD.Models
{
	public class transacties : INotifyPropertyChanged
	{
		private int _transactie_ID;
		public int Transactie_ID
		{
			get { return _transactie_ID; }
			set { _transactie_ID = value; OnPropertyChanged(); }
		}

		private string _rekeningen_Rekeningnummer;
		public string rekeningen_Rekeningnummer
		{
			get { return _rekeningen_Rekeningnummer; }
			set { _rekeningen_Rekeningnummer = value; OnPropertyChanged(); }
		}

		private DateTime _Datum_en_tijd;
		public DateTime Datum_en_tijd
		{
			get { return _Datum_en_tijd; }
			set { _Datum_en_tijd = value; OnPropertyChanged(); }
		}

		private decimal _Bedrag;
		public decimal Bedrag
		{
			get { return _Bedrag; }
			set { _Bedrag = value; OnPropertyChanged(); }
		}

		private string _Soort;
		public string Soort
		{
			get { return _Soort; }
			set { _Soort = value; OnPropertyChanged(); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}