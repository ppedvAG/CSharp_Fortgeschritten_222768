using System.Reflection;

namespace Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		Program p = new Program();
		Type pt = p.GetType(); //Typ holen mit GetType() über Objekt

		Type t = typeof(Program); //Typ holen durch typeof(<Klassenname>)

		object o = Activator.CreateInstance(pt); //Objekt erstellen über Type

		t.GetMethods(); //Alle Methoden anzeigen
		t.GetMethod("Test").Invoke(o, null); //Methode über Reflection ausführen
		t.GetMethod("Test2").Invoke(o, new[] { "Zwei Text" }); //Methode mit Parameter über Reflection ausführen

		t.GetField("EineZahl").SetValue(o, 5); //Feld über Reflection setzen
		Console.WriteLine(t.GetField("EineZahl").GetValue(o));

		t.GetProperty("EinText").SetValue(o, "Drei Text"); //Property über Reflection setzen
		Console.WriteLine(t.GetProperty("EinText").GetValue(o));

		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt nur über Strings erzeugen

		Assembly assembly = Assembly.GetExecutingAssembly(); //Information über das derzeitige Projekt erhalten

		List<TypeInfo> types = assembly.DefinedTypes.ToList(); //Alle Typen aus einem Assembly holen

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_12_13\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll";

		Assembly loaded = Assembly.LoadFrom(path); //DLL laden

		Type compType = loaded.GetType("DelegatesEvents.Component"); //Typ von Component holen

		object comp = Activator.CreateInstance(compType);
		compType.GetEvent("Progress").AddEventHandler(comp, (int i) => Console.WriteLine($"Fortschritt: {i}"));
		compType.GetEvent("ProcessCompleted").AddEventHandler(comp, () => Console.WriteLine("Fertig"));
		compType.GetMethod("StartProcess").Invoke(comp, null);
	}

	public int EineZahl;

	public string EinText { get; set; }

	public void Test()
	{
		Console.WriteLine("Ein Test");
	}

	public void Test2(string s)
	{
		Console.WriteLine(s);
	}
}