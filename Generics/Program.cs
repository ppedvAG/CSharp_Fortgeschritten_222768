namespace Generics;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new List<string>(); //Generic: T wird nach unten übernommen (hier T = string)
		list.Add("123"); //T wird durch string ersetzt Add(T) -> Add(string)

		List<int> ints = new List<int>(); //T wird durch int ersetzt
		ints.Add(1); //Add(T) -> Add(int)

		Dictionary<string, int> keyValuePairs = new Dictionary<string, int>(); //Klasse mit 2 Generics: TKey -> string, TValue -> int
		keyValuePairs.Add("123", 123); //Add(TKey, TValue) -> Add(string, int)
	}
}

public class DataStore<T> //Klassenname muss <T> enthalten
	: IProgress<T>, //T bei Vererbung weitergeben
	  IEquatable<int> //Fixer Typ auch möglich statt T
{
	private T[] data; //T als Typ

	public List<T> Data => data.ToList(); //Generic nach unten weitergeben

	public void Add(int index, T item) => data[index] = item; //T als Parameter

	public T GetIndex(int idx) //T als Rückgabewert
	{
		if (idx < 0 || idx > data.Length)
			return default(T); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		return data[idx];
	}

	public void Report(T value) => throw new NotImplementedException(); //T kommt vom Interface

	public bool Equals(int other) => throw new NotImplementedException();

	public void PrintType<MyType>() //Methode mit Generic, T von oben hier nicht nochmal definieren
	{
		Console.WriteLine(typeof(MyType)); //Typ Objekt des Typs generieren
		Console.WriteLine(nameof(MyType)); //Gibt den Namen des Typs aus ("MyType")
		Console.WriteLine(default(MyType)); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)

		//if (MyType is Single) //Nicht möglich
		//{

		//}

		if (typeof(MyType) == typeof(Single)) //Typvergleiche mit Generics müssen mit typeof gemacht werden
		{

		}
	}
}

public class DataStore2<T> : DataStore<T> { } //Klassen mit T vererben: braucht wieder T beim Klassennamen