namespace PluginBase
{
	public interface IPlugin
	{
		string Name { get; }

		string Description { get; }

		string Version { get; }
	}

	public interface ICalculatorPlugin : IPlugin
	{
		public double Addiere(double x, double y);
	}
}