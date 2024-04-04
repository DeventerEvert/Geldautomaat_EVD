using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldautomaat_EvD.Models
{
	public class klanten
	{
		public int Klantnummer { get; set; }
		public string Voornaam { get; set; }
		public string Achternaam { get; set; }
		public string Adres { get; set; }
		public string Contactgegevens { get; set; }
		public List<rekeningen> rekening { get; set; }
	}
}
