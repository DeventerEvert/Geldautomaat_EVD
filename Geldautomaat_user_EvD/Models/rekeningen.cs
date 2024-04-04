using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Geldautomaat_EvD.Models
{
	public class rekeningen : INotifyPropertyChanged
	{
		private string _rekeningnummer;
		private string _pincode;
		private decimal _saldo;
		private int _klanten_Klantnummer;
		private bool _Geblockt;
		private List<transacties> _transacties;

		public rekeningen(string rekeningnr, string pincode, decimal saldo, bool blocked, int fk_klantnr) { 
			_rekeningnummer = rekeningnr;
			_pincode = pincode;
			_saldo = saldo;
			_klanten_Klantnummer = fk_klantnr;
			_Geblockt = blocked;
		}

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

		public string Pincode
		{
			get { return _pincode; }
			set
			{
				if (_pincode != value)
				{
					_pincode = value;
					OnPropertyChanged(nameof(Pincode));
				}
			}
		}

		public decimal Saldo
		{
			get { return _saldo; }
			set
			{
				if (_saldo != value)
				{
					_saldo = value;
					OnPropertyChanged(nameof(Saldo));
				}
			}
		}

		public bool Geblockt
		{
			get { return _Geblockt; }
			set
			{
				if (_Geblockt != value)
				{
					_Geblockt = value;
					OnPropertyChanged(nameof(Geblockt));
				}
			}
		}

		public int klanten_Klantnummer
		{
			get { return _klanten_Klantnummer; }
			set
			{
				if (_klanten_Klantnummer != value)
				{
					_klanten_Klantnummer = value;
					OnPropertyChanged(nameof(klanten_Klantnummer));
				}
			}
		}

		public List<transacties> Transacties
		{
			get { return _transacties; }
			set
			{
				if (_transacties != value)
				{
					_transacties = value;
					OnPropertyChanged(nameof(Transacties));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
