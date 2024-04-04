using System;
using MySqlConnector;

namespace Geldautomaat_admin_EvD.Controllers
{
	public class SQL
	{

		private static MySqlConnection _connection;

		static SQL()
		{
			_connection = new MySqlConnection();
			_connection.ConnectionString = "Server=localhost;User ID=root; Password=; Database=geldautomaat; ConvertZeroDateTime=True";
			_connection.Open();
		}

		public static MySqlConnection Connection
		{
			get
			{
				return _connection;
			}
		}
	}
}
