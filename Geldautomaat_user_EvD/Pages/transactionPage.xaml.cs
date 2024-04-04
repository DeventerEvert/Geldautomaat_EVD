using Geldautomaat_EvD.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Geldautomaat_EvD.Pages
{
	public partial class Page2 : Page
	{
		public Page2(rekeningen rekeningObject)
		{
			InitializeComponent();
			DataContext = rekeningObject;

			var latestTransactions = rekeningObject.Transacties.OrderByDescending(t => t.Datum_en_tijd).Take(3);

			transactionsItemsControl.ItemsSource = latestTransactions;
		}
	
		private void backBtn_Click(object sender, RoutedEventArgs e)
		{
				MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
				if (mainWindow != null)
				{
					mainWindow.MainFrame.Visibility = Visibility.Visible;
					mainWindow.transactionFrame.Visibility = Visibility.Collapsed;
				}
			}
		}
}
