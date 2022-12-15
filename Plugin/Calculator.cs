using PluginBase;

namespace Plugin;

public class Calculator : ICalculatorPlugin
{
	public string Name => "Rechner";

	public string Description => "Ein Rechner der Addieren kann";

	public string Version => "1.0";

	public double Addiere(double z1, double z2) => z1 + z2;
}