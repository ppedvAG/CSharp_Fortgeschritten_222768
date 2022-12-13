namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(); //Variablentyp Mensch, kann alle Objekte halten die von Typ Mensch sind oder darunter in der Vererbungshiearchie

		Lebewesen l = new Mensch(); //Variablentyp Lebewesen, kann alle Objekte vom Typ Lebewesen oder darunter halten

		object o = new Mensch(); //Variablentyp Object, kann alle Objekte halten
		o = "Hallo"; //string
		o = 123; //int
		o = 12.34; //double
		o = false; //bool

		Console.WriteLine(m.GetType().Name); //Mensch
		Console.WriteLine(l.GetType()); //M009.Mensch
		Console.WriteLine(o.GetType()); //System.Boolean

		Type tm = m.GetType(); //GetType() gibt uns ein Type Objekt
		Type typeofMensch = typeof(Mensch); //Über typeof(<Klassenname>) einen Typen über eine Klasse extrahieren

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //ist m genau ein Mensch?
		{
			//true
		}

		if (m.GetType() == typeof(Lebewesen))
		{
			//false
		}
		#endregion

		#region Vererbungshiearchie Typvergleich
		if (m is Lebewesen)
		{
			//true
		}

		if (m is object)
		{
			//immer true
		}

		if (m is Mensch)
		{
			//true
		}

		if (m is Program)
		{
			//false
		}
		#endregion

		#region Virtual Override
		Mensch mensch = new Mensch();
		Console.WriteLine(mensch.WasBinIch()); //Ich bin ein Lebewesen und habe zwei Beine

		Lebewesen l2 = mensch;
		Console.WriteLine(l2.WasBinIch()); //Ich bin ein Lebewesen und habe zwei Beine
										   //Hier wird die Methode von Mensch verwendet
		#endregion

		#region New
		Mensch mensch2 = new Mensch();
		Console.WriteLine(mensch2.WasBinIch()); //Ich bin ein Lebewesen und habe zwei Beine

		Lebewesen l3 = mensch;
		Console.WriteLine(l3.WasBinIch()); //Ich bin ein Lebewesen
										   //Hier wird die Methode von Lebewesen verwendet, da die Verbindung getrennt wurde
		#endregion

		Lebewesen[] array = new Lebewesen[3];
		array[0] = new Mensch();
		array[1] = new Hund();
		array[2] = new Lebewesen();

		foreach (Lebewesen lw in array)
		{
			if (lw.GetType() == typeof(Mensch))
			{
				Mensch mensch1 = (Mensch) lw;
				mensch1.MenschMethode();
			}

			if (lw is Hund h)
			{
				//Hund h1 = (Hund) h; kann gespart werden durch Variblendeklaration in der if
				h.HundMethode();
			}
		}

		Bauteil b = new Fenster();
		Bauteil[] teile = { new Fenster(), new Fenster(), new Fenster() };
		//b = new Bauteil();
	}
}

public class Lebewesen
{
	public virtual string WasBinIch()
	{
		return "Ich bin ein Lebewesen";
	}

	//public string WasBinIch() -> new
	//{
	//	return "Ich bin ein Lebewesen";
	//}
}

public class Mensch : Lebewesen 
{
	public override string WasBinIch()
	{
		return base.WasBinIch() + " und habe zwei Beine";
	}

	//public new string WasBinIch() -> new
	//{
	//	return base.WasBinIch() + " und habe zwei Beine";
	//}

	public void MenschMethode()
	{

	}
}

public class Hund : Lebewesen
{
	public void HundMethode()
	{

	}
}