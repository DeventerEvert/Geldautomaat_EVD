using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Geldautomaat_EvD.Models
{
	public class admins : INotifyPropertyChanged
	{
		private int _admin_ID;
		private string _gebruikersnaam;
		private string _wachtwoord;

		public int Admin_ID
		{
			get { return _admin_ID; }
			set
			{
				if (_admin_ID != value)
				{
					_admin_ID = value;
					OnPropertyChanged(nameof(Admin_ID));
				}
			}
		}

		public string Gebruikersnaam
		{
			get { return _gebruikersnaam; }
			set
			{
				if (_gebruikersnaam != value)
				{
					_gebruikersnaam = value;
					OnPropertyChanged(nameof(Gebruikersnaam));
				}
			}
		}

		public string Wachtwoord
		{
			get { return _wachtwoord; }
			set
			{
				if (_wachtwoord != value)
				{
					_wachtwoord = value;
					OnPropertyChanged(nameof(Wachtwoord));
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
