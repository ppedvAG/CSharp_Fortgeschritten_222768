namespace Multitasking;

internal class _03_TaskBeenden
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new(); //Sender
		CancellationToken token = cts.Token; //Empfänger

		Task t = new Task(Run, token); //Hier Token direkt übergeben
		t.Start();

		Thread.Sleep(1000);

		cts.Cancel();

		Console.ReadKey();
	}

	static void Run(object o)
	{
		if (o is CancellationToken ct)
		{
			for (int i = 0; i < 100; i++)
			{
				if (ct.IsCancellationRequested)
					ct.ThrowIfCancellationRequested(); //Task wirft Exception ist aber nicht sichtbar

				Console.WriteLine($"Task: {i}");
				Thread.Sleep(100);
			}
		}
	}
}
