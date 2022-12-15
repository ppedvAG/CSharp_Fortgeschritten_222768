using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Progress.Value = 0;
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Progress.Value++;
			} //Thread.Sleep verhindert UI Updates
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Task.Run(() => //UI Updates von Side Tasks sind nicht erlaubt
			{
				Dispatcher.Invoke(() => Progress.Value = 0); //Dispatcher.Invoke um UI Updates auf dem Main Thread auszuführen
				for (int i = 0; i < 100; i++)
				{
					Thread.Sleep(25);
					Dispatcher.Invoke(() => Progress.Value++);
				}
			});
		}

		private async void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Progress.Value = 0;
			for (int i = 0; i < 100; i++)
			{
				await Task.Delay(25);
				Progress.Value++;
			}
		}

		private async void Button_Click_3(object sender, RoutedEventArgs e)
		{
			using HttpClient client = new HttpClient();
			string full = await client.GetStringAsync("http://www.gutenberg.org/files/54700/54700-0.txt");

			HttpResponseMessage resp = await client.GetAsync("http://www.gutenberg.org/files/54700/54700-0.txt");
			string full2 = await resp.Content.ReadAsStringAsync();

			Text.Text = full;

			//string[] responses = await Task.WhenAll(); //Ergebnisse von mehreren Tasks awaiten
		}

		private async void Button_Click_4(object sender, RoutedEventArgs e)
		{
			List<int> ints = Enumerable.Range(0, 100).ToList();
			await Parallel.ForEachAsync(ints, (item, ct) =>
			{
				System.Console.WriteLine(item * 10);
				return ValueTask.CompletedTask; //Normalerweise kein return in foreach -> Leerer Task
			});

			IAsyncEnumerable<int> liste = null;
			await foreach (var x in liste) { } //Foreach mit async davor
		}
	}
}
