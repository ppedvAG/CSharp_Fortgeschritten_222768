using System.Net;

namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange die Bedingung true ist
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife (bei verschachtelte Schleifen springt break aus der inneren Schleife heraus)
				a++;
			}

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //Continue: springt in den Schleifenkopf zurück (Code darunter wird ausgelassen)
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			while (true) //do-while mit while (true) aufgebaut
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine("do-while: " + c);

				if (c >= d)
					break;
			}

			//for + Tab + Tab
			for (int i = 0; i < 10; i++) //Variable wird am Anfang angelegt, dann wird die Bedingung überprüft, am Ende wird die Variable erhöht
			{
				Console.WriteLine("for: " + i); //i ist nur innerhalb der Schleife sichtbar
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine("forr: " + i);
			}

			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7 };
			for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
			{
				Console.WriteLine(zahlen[i]); //for Schleife kann daneben greifen, daher subobtimal um Arrays durchzugehen
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen) //Array durchgehen aber kann nicht daneben greifen
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen)
				Console.WriteLine(item); //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
			#endregion

			#region Enums
			string heutigerTag = "Dienstag";
			if (heutigerTag == "dienstag")
			{
				//Fehleranfälligkeit bei Strings
			}
			
			Wochentag wt = Wochentag.Do; //Variable vom Enum Typ
			if (wt == Wochentag.Di)
			{
				//Keine Fehleranfälligkeit
			}

			//Jeder Enum Wert hat einen int dahinter
			int x = 2;
			Wochentag cast = (Wochentag) x; //int zu Wochentag casten

			string tag = "Mo";
			Wochentag einTag = Enum.Parse<Wochentag>(tag); //String zu Enum parsen (funktioniert mit Mo oder Zahl z.B. 1)

			string input = Console.ReadLine();
			Console.WriteLine(Enum.Parse<Wochentag>(input)); //Usereingabe zu einem Enum parsen (Mo oder 0)

			Wochentag[] tage = Enum.GetValues<Wochentag>(); //Aus einem Enum alle Werte in ein Array entnehmen
			foreach (Wochentag t in tage) //Über alle Enumwerte iterieren
			{
				Console.WriteLine(tage);
			}
			#endregion

			#region Switch
			int z = 5;
			switch (z) //if-else Baum mit switch
			{
				case 1: //Sozusagen eine if
					Console.WriteLine("z ist 1");
					break; //Am Ende von jedem Case ein break machen
				case 2:
					Console.WriteLine("z ist 2");
					break;
				case 5:
					Console.WriteLine("z ist 5");
					break;
				default: //Sozusagen eine else
					Console.WriteLine("z ist eine andere Zahl");
					break;
			}

			switch (wt)
			{
				case Wochentag.Mo:
					Console.WriteLine("Wochenanfang");
					break;
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				//default case kann weggelassen werden
			}

			//Switch mit boolscher Logik
			switch (wt)
			{
				//and/or statt &&/||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
			}
			#endregion
		}
	}

	enum Wochentag
	{
		Mo = 1, Di, Mi, Do = 10, Fr, Sa, So //Standardwerte von einzelnen Enumwerten setzen, Enumwerte danach sind aufsteigend
	}
}