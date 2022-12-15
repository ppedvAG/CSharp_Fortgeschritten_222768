using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Benchmarks;

internal class Program
{
	static void Main(string[] args)
	{
		BenchmarkRunner.Run<Benchmarks>();
		//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
		//Zum Debuggen auf Debug umschalten, obere Zeile auskommentieren
	}
}