using Geldautomaat_EvD.Models;
using Mysqlx.Connection;
using Mysqlx.Cursor;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Geldautomaat_EvD.Pages
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class Page1 : Page
	{
		Controllers.geldautomaat_controller geldautomaatObject;
		private klanten klantObject;
		private rekeningen rekeningObject;
		private transacties transactieObject;
		public Page1(klanten klant, rekeningen rekeningObject)
		{
			InitializeComponent();
			geldautomaatObject = new Controllers.geldautomaat_controller();
			this.DataContext = geldautomaatObject;
			klantObject = klant;
			this.rekeningObject = rekeningObject;
		}

		private void toonSaldo_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				showBalance depositPage = new showBalance(rekeningObject);
				mainWindow.MainFrame.Visibility = Visibility.Collapsed;
				mainWindow.balanceFrame.Visibility = Visibility.Visible;

				mainWindow.balanceFrame.Navigate(depositPage);
			}
		}

		private void geldOpnemen_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				withdrawPage withdrawPage = new withdrawPage(rekeningObject);
				mainWindow.MainFrame.Visibility = Visibility.Collapsed;
				mainWindow.withdrawFrame.Visibility = Visibility.Visible;

				mainWindow.withdrawFrame.Navigate(withdrawPage);
			}
		}

		private void geldStorten_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				Page3 depositPage = new Page3(rekeningObject);
				mainWindow.MainFrame.Visibility = Visibility.Collapsed;
				mainWindow.depositFrame.Visibility = Visibility.Visible;

				mainWindow.depositFrame.Navigate(depositPage);
			}
		}

		private void transacties_Tonen(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				Page2 transactionPage = new Page2(rekeningObject);
				mainWindow.MainFrame.Visibility = Visibility.Collapsed;
				mainWindow.transactionFrame.Visibility = Visibility.Visible;

				mainWindow.transactionFrame.Navigate(transactionPage);
			}
		}

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
