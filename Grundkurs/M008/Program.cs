using M008.Raum;

namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 23);
		Console.WriteLine($"{m.Name} {m.Alter}"); //Member die von oben kommen
		m.WasBinIch();

		Lebewesen l = new Lebewesen("Max");
		//l.Alter nicht möglich

		l.WasBinIch2();
		Console.WriteLine();
		m.WasBinIch2();

		Raum2 r = new Raum2();
		r.Teile[0] = new Fenster();
		r.Teile[1] = new Tuere();
		r.Teile[2] = new Fenster();
		r.Teile[3] = new Fenster();
	}
}

public class Lebewesen //Basisklasse
{
	public string Name { get; set; } //Wird nach unten vererbt

	public Lebewesen(string name)
	{
		Name = name;
	}

	public void WasBinIch() //Wird auch nach unten vererbt
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public virtual void WasBinIch2() //virtual: kann überschrieben werden, muss aber nicht überschrieben werden
	{
		Console.Write("Ich bin ein Lebewesen");
	}
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{ //sealed: Überschreibung verhindern
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Mit base Konstruktoren verketten im Vererbungskontext
	{
		//Extra Feld hinzufügen im Konstruktor (hier alter)
		Alter = alter;
	}

	//sealed: Überschreibung verhindern
	public sealed override void WasBinIch2() //override: Überschreibe die Methode von oben, obere Methode muss virtual sein 
	{
		base.WasBinIch2(); //Die Methode der Oberklasse aufrufen
		Console.WriteLine($" und bin {Alter} Jahre alt.");
	}
}

//public class Kind : Mensch
//{
//	public Kind(string name, int alter) : base(name, alter)
//	{
//	}

//	public override void WasBinIch2()
//	{
//		base.WasBinIch2();
//	}
//}