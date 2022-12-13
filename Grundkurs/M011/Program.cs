using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		List<int> list = new List<int>(); //Erstellung einer Liste mit einem Generic
		list.Add(1); //T wird ersetzt durch int
		list.Add(2); //T wird ersetzt durch int
		list.Add(3); //T wird ersetzt durch int
		list.Add(4); //T wird ersetzt durch int
		list.Remove(3); //Entfernt das erste Element das der Bedingung entspricht
		list.RemoveAt(0); //Entfernt ein Element anhand eines Indizes

		List<string> strList = new();
		strList.Add("Test"); //T wird ersetzt durch string

		Console.WriteLine(list[0]); //Funktioniert genau wie beim Array

		Console.WriteLine(list.Count); //Count statt Length, nicht Count() benutzen

		list[1] = 5; //Zuweisung genau wie beim Array

		list.Sort(); //Liste sortieren (funktioniert einfach bei int, string, double, ...)

		foreach (int item in list) //Liste iterieren wie beim Array
		{
			Console.WriteLine(item);
		}

		if (list.Contains(2))
		{
			//...
		}

		list.Clear(); //Alle Elemente entfernen

		Stack<int> intStack = new(); //Target-Typed new: Ergänzt Typ von links bei der Variablendeklaration, Konstruktor kann normal verwendet werden
		intStack.Push(1); //Elemente auflegen
		intStack.Push(2); //Strg + D: Derzeitige Zeile kopieren
		intStack.Push(3);
		intStack.Push(4);
		intStack.Push(5);

		Console.WriteLine(intStack.Peek()); //Oberstes Element anschauen (5)

		Console.WriteLine(intStack.Pop()); //Oberstes Element entfernen (5 wird entfernt)

		Queue<int> intQueue = new();
		intQueue.Enqueue(1);
		intQueue.Enqueue(2);
		intQueue.Enqueue(3);
		intQueue.Enqueue(4);

		Console.WriteLine(intQueue.Peek()); //Erstes Element anschauen (1)

		Console.WriteLine(intQueue.Dequeue()); //Erstes Element entfernen (1 wird entfernt)

		Dictionary<string, int> einwohnerzahlen = new(); //Liste von Key-Value paaren, Keys müssen eindeutig sein
		einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter (Key = string, Value = int)
		einwohnerzahlen.Add("Berlin", 3_650_000); //Tausendertrennzeichen mit _ (funktioniert auch bei double im Kommabereich)
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); ArgumentException

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary mit [] angreifen über den Key (hier string), Value als Ergebnis

		if (einwohnerzahlen.ContainsKey("Wien")) //Überprüfen ob ein Key existiert
			Console.WriteLine(einwohnerzahlen["Wien"]);

		einwohnerzahlen.ContainsValue(2_000_000); //Überprüfen ob ein Value existiert

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //Dictionary durchgehen mit KeyValuePair<Key, Value>
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner."); //mit kv.Key und kv.Value auf Inhalt zugreifen
		}

		Console.WriteLine(einwohnerzahlen.Keys); //Nur auf Keys zugreifen
		Console.WriteLine(einwohnerzahlen.Values); //Nur auf Values zugreifen

		SortedDictionary<string, int> einwohnerzahlenSorted = new(); //Sortiert sich bei jedem Add automatisch nach dem Key (Achtung: Perfomance)
		einwohnerzahlenSorted.Add("Wien", 2_000_000);
		einwohnerzahlenSorted.Add("Berlin", 3_650_000); //Berlin vor Wien
		einwohnerzahlenSorted.Add("Paris", 2_160_000); //Paris zwischen Berlin und Wien

		ObservableCollection<string> str = new(); //Benachrichtigt, wenn sich in der Liste was ändert
		str.CollectionChanged += Str_CollectionChanged; //Immer wenn sich in der Liste etwas ändert, wird die angehängte Methode ausgeführt
		str.Add("X");
		str.Add("Y");
		str.Add("Z");
		str.Remove("X");
	}

	private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Ein Element wurde hinzugefügt {e.NewItems[0]}"); //Mit NewItems und OldItems auf die bearbeiteten Elemente zugreifen
				break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Ein Element wurde entfernt {e.OldItems[0]}");
				break;
			//case NotifyCollectionChangedAction.Replace:
			//	break;
			//case NotifyCollectionChangedAction.Move:
			//	break;
			//case NotifyCollectionChangedAction.Reset:
			//	break;
		}
	}
}