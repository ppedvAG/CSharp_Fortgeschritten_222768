using System.Text;

namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start (0) mit einer bestimmten Anzahl Elemente (20)
		//(5, 20) -> Liste von 5 bis 24
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Gibt das erste Element, Exception falls kein Element
		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element zurück, null falls kein Element
		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Exception

		Console.WriteLine(ints.Last());
		Console.WriteLine(ints.LastOrDefault());
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit foreach
		List<Fahrzeug> bmwsForeach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForeach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmws = (from f in fahrzeuge
							   where f.Marke == FahrzeugMarke.BMW
							   select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Komplexes Linq
		//Alle Fahrzeuge mit MaxV >= 200
		fahrzeuge.Where(e => e.MaxV >= 200);

		//Alle VWs mit MaxV >= 200
		fahrzeuge.Where(e => e.MaxV >= 200 && e.Marke == FahrzeugMarke.VW);

		//Autos sortieren nach Automarke
		//Originale Liste bleibt bestehen
		fahrzeuge.OrderBy(e => e.Marke);
		fahrzeuge.OrderByDescending(e => e.Marke);

		//Nach Marke und dann nach MaxV
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Marken aus der Liste auslesen
		List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();

		//Marken einzigartig mchen
		marken.Distinct();

		//Fahren alle Fahrzeuge schneller als 200km/h?
		fahrzeuge.All(e => e.MaxV > 200);

		//Fährt mindestens ein Fahrzeug schneller als 300km/h?
		fahrzeuge.Any(e => e.MaxV > 300);

		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Where vereinfachen
		fahrzeuge.Where(e => e.MaxV > 0).Any();
		fahrzeuge.Any(e => e.MaxV > 0);
		fahrzeuge.Where(e => e.MaxV > 0).First();
		fahrzeuge.First(e => e.MaxV > 0);

		//Zähle die Anzahl an VWs
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		//Die kleinste Geschwindigkeit
		fahrzeuge.Min(e => e.MaxV);

		//Das langsamste Auto
		fahrzeuge.MinBy(e => e.MaxV);

		//Select vereinfachen
		fahrzeuge.Select(e => e.MaxV).Sum();
		fahrzeuge.Sum(e => e.MaxV);
		fahrzeuge.Select(e => e.MaxV).Average();
		fahrzeuge.Average(e => e.MaxV);

		//Liste in X-große Teile aufteilen
		fahrzeuge.Chunk(5);

		//Teile der Liste überspringen und/oder nehmen
		fahrzeuge.Skip(2).Take(5);

		//Dreht die Liste um
		//Generic angeben um Linq Reverse zu benutzen (sonst List Reverse)
		fahrzeuge.Reverse<Fahrzeug>();

		//ID hinzufügen
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count));
		Enumerable.Range(0, fahrzeuge.Count)
			.Zip(fahrzeuge)
			.ToDictionary(e => e.First, e => e.Second);

		//Nach Fahrzeugen gruppieren
		Dictionary<FahrzeugMarke, List<Fahrzeug>> grouped = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.ToList());

		//Einzelne Gruppe ansprechen
		grouped[FahrzeugMarke.BMW].Where(e => e.MaxV > 200);

		//Maximalgeschwindigkeiten aufsummieren
		fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxV);

		//Liste ausgeben
		string output = fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n");
		Console.WriteLine(output);

		fahrzeuge.Aggregate(new StringBuilder(), (agg, fzg) => agg.AppendLine($"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.")).ToString();

		List<Person> personen = new() { new Person(0, "Lukas", "Kern"), new Person(1, "Lukas", "Kern"), new Person(2, "Bettina", "Pfaff") };
		Dictionary<string[], int> x = personen
			.GroupBy(e => new[] { e.VN, e.NN })
			.ToDictionary(e => e.Key, e => e.Count());
		x.Where(e => e.Value >= 2).ToList();
		#endregion

		#region Erweiterungsmethode
		int zahl = 524390;
		zahl.Quersumme();

		Console.WriteLine(32850.Quersumme());

		fahrzeuge.Shuffle(); //Eigene Linq Funktion
		#endregion
	}
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

public record Person(int ID, string VN, string NN);

public enum FahrzeugMarke { Audi, BMW, VW }