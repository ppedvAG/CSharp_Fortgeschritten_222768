using PluginBase;
using System.Reflection;

namespace PluginClient;

internal class Program
{
	static void Main(string[] args)
	{
		//ICalculatorPlugin calc = Activator.CreateInstance("Plugin", "Plugin.Calculator") as ICalculatorPlugin;
		//calc.Addiere(4, 5);

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_12_13\Plugin\bin\Debug\net6.0\Plugin.dll";
		Assembly loaded = Assembly.LoadFrom(path);
		Type calc = loaded.DefinedTypes.Where(e => e.GetInterface("IPlugin") != null).First();
		object o = Activator.CreateInstance(calc);

		Console.WriteLine("Wähle eine Methode aus:");
		for (int i = 0; i < calc.GetMethods().Length; i++)
		{
			Console.WriteLine($"{i + 1}: {calc.GetMethods()[i]}");
		}

		int auswahl = int.Parse(Console.ReadLine());
		Console.WriteLine(calc.GetMethods()[auswahl - 1].Invoke(o, new object[] { 3.3, 7.1 }));
	}
}