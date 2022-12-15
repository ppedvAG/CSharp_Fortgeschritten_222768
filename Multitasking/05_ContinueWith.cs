namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		Task<double> t1 = Task.Run(() => 
		{
			Thread.Sleep(1000);
			return Math.Pow(4, 23);
		});
		t1.ContinueWith(t => Console.WriteLine(t.Result)); //Tasks verketten, Code wird ausgeführt wenn originaler Task fertig, Variable die uns den vorherigen Task gibt
		t1.ContinueWith(t => Console.WriteLine(t.Result * 2), TaskContinuationOptions.OnlyOnRanToCompletion); //Dieser Pfad wird betreten wenn keine Exception aufgetreten ist
		//Es können mehrere Folgetasks ausgeführt werden
		t1.ContinueWith(t => Console.WriteLine("Exception"), TaskContinuationOptions.OnlyOnFaulted); //Nur wenn eine Exception aufgetreten ist
		t1.ContinueWith(t => Console.WriteLine(), TaskContinuationOptions.NotOnFaulted); //Wenn keine unhandled Exception
		
		Console.ReadKey();
	}
}
