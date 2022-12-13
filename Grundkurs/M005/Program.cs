namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(10, 5); //Funktionsaufruf über den Namen der Funktion, Parameter müssen mit angegeben werden
			PrintAddiere(2, 3);
			PrintAddiere(8, 10);

			int x = Addiere(4, 2); //Ergebnis der Addiere Funktion in eine Variable schreiben
			Console.WriteLine(Addiere(4, 2)); //Ergebnis der Addiere Funktion direkt weitergeben an CW

			//F12: Zu Definition springen
			Console.WriteLine(); //-> 17 Overloads für alle möglichen Parameter (int, string, char, ...)

			double y = Addiere(2d, 2.0); //Double Addiere erzwingen durch mindestens ein double bei den Parametern

			double z = Addiere(1, 2, 3, 4, 5, 6); //Bei Params können beliebig viele Parameter angegeben werden
			z = Addiere(3, 5, 6);
			z = Addiere(); //Auch keine Parameter sind valide

			Subtrahiere(3, 1); //Optionalen Parameter verwenden mit Standardwert
			Subtrahiere(8, 4, 1); //Optionalen Parameter überschreiben

			SubtrahiereOderAddiere(6, 3);
			SubtrahiereOderAddiere(8, 103);
			SubtrahiereOderAddiere(8, 13);
			SubtrahiereOderAddiere(6, 3, false);

			int add;
			int sub = SubtrahiereUndAddiere(4, 2, out add); //Mit dem out Keyword eine Variable ansteuern

			//int result = 0;
			if (int.TryParse("123", out int result)) //Kurzform von out, definiert int result darüber
			{
				Console.WriteLine(result);
			}
			else
				Console.WriteLine("Parsen hat nicht funktioniert");

			PrintWochentag(Wochentag.Fr); //Nur fixe Werte möglich wegen Enum

			var ret = DreiReturns(); //Tupel mit var um die Namen beizubehalten
			Console.WriteLine(ret.z1);
			Console.WriteLine(ret.z2);
			Console.WriteLine(ret.str);
		}

		static void PrintAddiere(int z1, int z2) //Funktion mit void (kein Rückgabewert), Zwei Parameter: z1, z2
		{
			Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
		}

		static int Addiere(int z1, int z2) //Funktion mit Rückgabewert
		{
			return z1 + z2; //Ergebnis der Funktion zurückgeben
		}

		static double Addiere(double z1, double z2) //Funktionen überladen: Funktionen mit gleichem Namen definieren wie bereits vorhandene Funktionen, nur mit anderen Parameters
		{
			return z1 + z2;
		}

		static double Addiere(params double[] zahlen) //Mit Params können beliebig viele Parameter angegeben werden (muss ein Array sein)
		{
			return zahlen.Sum(); //Hier unten kann man zahlen einfach als Array angreifen
		}

		static double Subtrahiere(int z1, int z2, int z3 = 0, int z4 = 0) //Optionaler Parameter: Kann bei Funktionsaufruf übergeben werden, muss aber nicht
		{
			return z1 - z2 - z3;
		}

		static int SubtrahiereOderAddiere(int z1, int z2, bool add = true) //Optionale Parameter müssen die letzten Parameter sein
		{
			//if (add)
			//	return z1 + z2;
			//else
			//	return z1 - z2;
			return add ? z1 + z2 : z1 - z2;
		}

		static int SubtrahiereUndAddiere(int z1, int z2, out int add) //Out-Parameter: Mehrere Werte zurückgeben
		{
			add = z1 + z2; //Muss zugewiesen werden vor return
			return z1 - z2;
		}

		static string PrintWochentag(Wochentag w)
		{
			switch (w)
			{
				case Wochentag.Mo: return "Montag"; //Bei einem switch mit return muss kein break verwendet werden
				case Wochentag.Di: return "Dienstag";
				case Wochentag.Mi: return "Mittwoch";
				case Wochentag.Do: return "Donnerstag";
				case Wochentag.Fr: return "Freitag";
				case Wochentag.Sa: return "Samstag";
				case Wochentag.So: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}

		static void PrintZahl(int zahl)
		{
			Console.WriteLine(zahl);
			return; //Aus Funktion herausspringen / Funktion beenden
			Console.WriteLine(zahl); //Kann nicht erreicht werden
		}

		static (int z1, int z2, string str) DreiReturns() //Tupel um mehrere Werte zurückgeben
		{
			return (3, 8, "Hallo");
		}
	}

	public enum Wochentag
	{
		Mo,
		Di,
		Mi,
		Do,
		Fr,
		Sa,
		So
	}
}