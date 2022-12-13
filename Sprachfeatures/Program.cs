namespace Sprachfeatures;

internal class Program
{
	readonly int Zahl; //Nur im Konstruktor oder bei der Variable selber setzbar

	static void Main(string[] args)
	{
		object obj = 3;
		if (obj is int i)
		{
			//int i = (int) obj;
			Console.WriteLine(i * 2);
		}

		double d = 5_2_3_4_6_5_435.243_685_294_____2;

		void Test() => Console.WriteLine("Test");

		Exp(z2: 3, z1: 9);

		string name = "lukas";

		string nameFix = char.ToUpper(name[0]) + name[1..].ToLower();

		char c = 'A';

		string name2 = name != null ? name : throw new Exception();
		string name3 = name ?? throw new Exception();

		JsonSerializer.Serialize(obj);

		//Person P(Person x) => x switch
		//{
		//	{ Vorgesetzter.Vorgesetzter.Vorgesetzter == null } => null,
		//	{ Vorgesetzter: { Vorgesetzter: { Vorgesetzter == null } } }
		//}

		string str = $"Das ist ein \" {123} sehr langer string";
	}

	static void Exp(int z1, int z2) => Console.WriteLine("Test");

	static string SwitchPattern(int x)
	{
		return x switch
		{
			1 => "Eins",
			2 => "Zwei",
			3 => "Drei",
			_ => "Andere Zahl"
		};
	}
}

public record Person(string Name, int Alter, Person Vorgesetzter)
{
	public void Test()
	{

	}
}