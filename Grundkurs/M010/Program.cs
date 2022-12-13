using System.Collections;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch() { Gehalt = 3000, Job = "Softwareentwickler" }; //Direkte Initialisierung von bestimmten Feldern
		//m.Lohnauszahlung(); //Lohnauszahlungsmethode durch Interface

		IArbeit a = m; //Variable vom Typ IArbeit genau wie bei Vererbung
		a.Lohnauszahlung();

		ITeilzeitarbeit ta = m;
		ta.Lohnauszahlung();

		//IEnumerable: Basisinterface von allen Listen in C#, Linq Funktion für all diese Objekte möglich
		int[] x;
		List<int> y;
		Dictionary<int, int> z;

		//Test(x);
		//Test(y);
		//Test(z);
	}

	static void Test(IEnumerable x) //Jeder Listentyp möglich
	{

	}
}

public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static int Wochenstunden = 40;

	int Gehalt { get; set; }

	string Job { get; set; } //Properties werden weitergegeben

	void Lohnauszahlung(); //Methode ohne Body wie bei Abstrakten Methoden

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitarbeit : IArbeit //Interfaces vererbung
{
	static new int Wochenstunden = 20;

	new void Lohnauszahlung();
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitarbeit
{
	public int Gehalt { get; set; }

	public string Job { get; set; }

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} bekommen. Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche.");
	}

	void ITeilzeitarbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2}€ für den Job {Job} bekommen. Er arbeitet {ITeilzeitarbeit.Wochenstunden} Stunden pro Woche.");
	}
}