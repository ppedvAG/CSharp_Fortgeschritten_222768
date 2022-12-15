namespace Multitasking;

internal class _06_WhenAll
{
	static void Main(string[] args)
	{
		List<Task<int>> ints = new List<Task<int>>();
		for (int i = 0; i < 1000; i++)
		{
			ints.Add(Task.Run(() => i * i));
		}

		Task<int[]> ergebnisse = Task.WhenAll(ints); //gibt einen Task<int[]>
		int[] erg = ergebnisse.Result; //Ergebnis extrahieren
	}
}
