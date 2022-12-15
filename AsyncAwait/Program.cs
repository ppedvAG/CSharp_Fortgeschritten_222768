using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		//Stopwatch sw = Stopwatch.StartNew(); //Sequentiell, ineffizient
		//Toast();
		//Geschirr();
		//Kaffee();
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //7s

		//Stopwatch sw2 = Stopwatch.StartNew();
		//Task.Run(Toast);
		//Task.Run(Geschirr);
		//Task.Run(Kaffee);
		//sw2.Stop();
		//Console.WriteLine(sw2.ElapsedMilliseconds); //2ms, Main Thread läuft weiter
		//Console.ReadKey();

		//Stopwatch sw3 = Stopwatch.StartNew();
		//ToastTaskAsync(); //Methoden werden als Tasks ausgeführt weil sie als async gekennzeichnet sind
		//GeschirrTaskAsync();
		//KaffeeTaskAsync();
		//sw3.Stop();
		//Console.WriteLine(sw3.ElapsedMilliseconds); //30ms, Main Thread läuft weiter

		//Stopwatch sw4 = Stopwatch.StartNew();
		//Task<Toast> toast = ToastAsync(); //Task wird hier auch direkt gestartet
		//Task<Tasse> tasse = GeschirrAsync();
		//Tasse t = await tasse;
		//Task<Kaffee> kaffee = KaffeeAsync(t);
		//Kaffee k = await kaffee;
		//Toast essen = await toast;
		//sw4.Stop();
		//Console.WriteLine(sw4.ElapsedMilliseconds); //4s

		//Toast t = await ToastAsync();
		//Tasse t2 = await GeschirrAsync();
		//Kaffee k = await KaffeeAsync(t2); //Kaffee k = await KaffeeAsync(await GeschirrAsync());
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Geschirr()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async void ToastTaskAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async void GeschirrTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static async void KaffeeTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async Task<Toast> ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> GeschirrAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee zubereitet");
		return new Kaffee();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }