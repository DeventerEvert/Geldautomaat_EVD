using Geldautomaat_EvD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for showBalance.xaml
    /// </summary>
    public partial class showBalance : Page
    {
		rekeningen saldoObject;
		public showBalance(rekeningen rekeningObject)
		{
			InitializeComponent();
			this.saldoObject = rekeningObject;
			this.DataContext = saldoObject;
		}

		private void saldoBack_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
			if (mainWindow != null)
			{
				mainWindow.MainFrame.Visibility = Visibility.Visible;
				mainWindow.balanceFrame.Visibility = Visibility.Collapsed;
			}
		}
	}
}
