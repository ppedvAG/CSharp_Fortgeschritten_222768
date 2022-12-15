using System.Collections;

namespace Sonstiges;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Zug z = new();
		z += w1;
		z += w2;

		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z) { }

		//z[1] = new();
		//Console.WriteLine(z["Rot"]);
		//Console.WriteLine(z[3, "Rot"]);
	
		System.Timers.Timer t = new System.Timers.Timer();
		t.Interval = 1000;
		t.Elapsed += (sender, e) => Console.WriteLine("1s ist vergangen");
		t.Start();

		Console.ReadKey();
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons = new();

	public Wagon this[int idx]
	{
		get => Wagons[idx];
		set => Wagons[idx] = value;
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe== farbe);
	}

	public Wagon this[int anz, string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe && e.AnzSitze == anz);
	}

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}
}

public class Wagon
{
	public int AnzSitze;

	public string Farbe;

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}