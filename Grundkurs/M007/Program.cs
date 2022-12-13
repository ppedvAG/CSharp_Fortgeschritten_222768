using M007.Bauteile;

namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 10; i++)
			{
				Fenster f = new Fenster();
			}

			GC.Collect(); //Hier GC erzwingen
			GC.WaitForPendingFinalizers(); //Warte auf Destruktoren
			#endregion

			#region Static
			//Statische Member müssen ohne Objekt arbeiten
			//Console c = new Console();
			//c.WriteLine(); nicht möglich, da statisch
			//Console.WriteLine();

			Fenster fenster = new Fenster();
			//f.Counter nicht möglich
			Console.WriteLine(Fenster.Counter);
			//f.ZaehleFenster(); nicht möglich
			Fenster.ZaehleFenster();
			#endregion

			#region Werte-/Referenztyp
			//Wertetyp
			int original = 5;
			int x = original; //Kopie von 5
			original = 10;

			//Referenztyp
			Fenster f1 = new Fenster();
			Fenster f2 = f1; //Referenz zwischen f1 und f2
			f1.FensterOeffnen();

			//class: Referenztyp, struct: Wertetyp
			#endregion

			#region Null
			Fenster f4; //Standardwert: null
			f4 = null; //Variable entleeren

			//f4.FensterOeffnen(); Nicht vorhandenes Fenster kann nicht geöffnet werden
			if (f4 == null) //Erstmal ein Fenster erstellen wenn es nicht existiert
			{
				f4 = new Fenster();
			}

			if (f4 != null) //Wenn Fenster existiert es öffnen
			{
				f4.FensterOeffnen();
			}

			if (f4 is null || f4 is not null) //Selbiges wie == und != nur schöner
			{

			}
			#endregion
		}
	}
}