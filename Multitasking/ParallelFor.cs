using System.Diagnostics;

namespace Multitasking;

internal class ParallelForDemo
{
	static void Main(string[] args)
	{
		int[] durchgänge = { 1000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };

		foreach (int i in durchgänge)
		{
			Stopwatch sw = Stopwatch.StartNew();
			RegularFor(i);
			sw.Stop();
			Console.WriteLine($"For Durchgänge {i}: {sw.ElapsedMilliseconds}ms");

			Stopwatch sw2 = Stopwatch.StartNew();
			ParallelFor(i);
			sw2.Stop();
			Console.WriteLine($"Parallel For Durchgänge {i}: {sw2.ElapsedMilliseconds}ms");
		}

		/*
		    For Durchgänge 1000: 1
			Parallel For Durchgänge 1000: 166
			For Durchgänge 10000: 5
			Parallel For Durchgänge 10000: 106
			For Durchgänge 50000: 23
			Parallel For Durchgänge 50000: 55
			For Durchgänge 100000: 44
			Parallel For Durchgänge 100000: 32
			For Durchgänge 250000: 139
			Parallel For Durchgänge 250000: 89
			For Durchgänge 500000: 240
			Parallel For Durchgänge 500000: 137
			For Durchgänge 1000000: 763
			Parallel For Durchgänge 1000000: 244
			For Durchgänge 5000000: 2662
			Parallel For Durchgänge 5000000: 507
			For Durchgänge 10000000: 3080
			Parallel For Durchgänge 10000000: 860
			For Durchgänge 100000000: 32598
			Parallel For Durchgänge 100000000: 12033
		 */
	}

	static void RegularFor(int iterations)
	{
		double[] erg = new double[iterations];
		for (int i = 0; i < iterations; i++)
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
	}

	static void ParallelFor(int iterations)
	{
		double[] erg = new double[iterations];
		//int i = 0; i < iterations; i++
		Parallel.For(0, iterations, i => erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100));
	}
}
