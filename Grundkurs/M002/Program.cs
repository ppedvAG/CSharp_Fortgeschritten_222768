namespace M002
{
	/// <summary>
	/// Die Program Klasse
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args">Die Programmargumente</param>
		static void Main(string[] args)
		{
			#region Variablen
			//Variable: Feld das einen Wert halten kann
			int zahl; //Deklaration
			zahl = 5; //Zuweisung
					  //int: Ganze Zahl
			Console.WriteLine(zahl); //Eine Ausgabe auf die Konsole machen

			int zahlMitZuweisung = 5; //Deklaration und Zuweisung gemeinsam
			Console.WriteLine(zahlMitZuweisung); //cw + Tab + Tab

			int zahlMalZwei = zahl * 2; //obere Zahl mal 2 = 10
			Console.WriteLine(zahlMalZwei);

			/*
			 * Mehrzeiliger
			 * Kommentar
			 */

			string wort = "Hallo"; //String: Text mit maximal 4 Milliarden Zeichen, braucht doppelte Hochkomma
			Console.WriteLine(wort);

			char zeichen = 'A'; //Char: kann genau ein Zeichen halten, braucht einzelne Hochkomma
			Console.WriteLine(zeichen);

			double kostenDouble = 38.29; //double: Kommazahl
			Console.WriteLine(kostenDouble);

			float kostenFloat = 49.28f; //Kommazahlen sind standardmäßig double, mit f zu float konvertieren

			decimal kostenDecimal = 45.22m; //Geeignet für Geldwerte da sehr hohe Kommastellenpräzision, mit m zu decimal konvertieren

			bool b = true; //bool: Wahr/Falschwert
			b = false; //true oder false
			#endregion

			#region Strings
			string kombi = "Das Wort ist: " + wort; //Stringverknüpfung mit +
			Console.WriteLine(kombi);

			string kombiInt = "Die Zahl ist: " + zahl; //Stringverknüpfung auch möglich mit Ints (oder anderen Typen)
			Console.WriteLine(kombiInt);

			string abstand = "Die Werte sind: " + wort + ", " + zahl + ", " + b; //Anstrengend
			Console.WriteLine(abstand);

			//String-Interpolation: mit $ Zeichen vor dem String Code im String schreiben
			string interpolation = $"Die Werte sind: {wort}, {zahl}, {b}"; //Einfacher als obiges mit Interpolation
			Console.WriteLine(interpolation);

			Console.WriteLine($"Die Werte sind: {wort}, {zahl}, {b}"); //Direkte Ausgabe statt mit extra Variable

			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Umbruch \n Umbruch"); //\n für Zeilenumbruch

			Console.WriteLine("Tab \t Tab"); //\t für Tabulator

			Console.WriteLine("C:\\Users\\lk3"); //Doppelter Backslash um einzelnen Backslash

			//Verbatim-String: Nimmt den String 1:1 wie er geschrieben wird, beachtet keine Escape-Sequenzen
			string verbatim = @"\n\t\\";
			Console.WriteLine(verbatim);

			string umbruch = @"Umbruch
				Umbruch"; //Umbrüche müssen tatsächliche Umbrüche sein
			Console.WriteLine(umbruch);

			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2022_10_18"; //Verbatim String ist besonders nützlich bei Pfaden
			Console.WriteLine(pfad);
			#endregion

			#region Eingabe
			//string eingabe = Console.ReadLine(); //Mit Console.ReadLine() eine Eingabe vom Benutzer verlangen, Programm bleibt stehen bis Enter gedrückt wird
			//Console.WriteLine(eingabe); //Das Ergebnis vom Benutzer wird in die eingabe Variable geschrieben, danach können wir damit arbeiten
			//Console.WriteLine("Das Wort ist: " + eingabe);

			//char eingabeChar = Console.ReadKey().KeyChar; //ReadKey: Warte auf einen Input vom User ohne Enter
			//Console.WriteLine(eingabeChar);

			////int parseInt = eingabe; //Passt nicht zusammen weil string nicht in int passt
			//int parseInt = int.Parse(eingabe); //mit int.Parse einen String zu einem Int konvertieren
			//Console.WriteLine(parseInt * 5);

			//double parseDouble = double.Parse(eingabe); //die Parse Funktion gibt es auch in anderen Klassen (double, float, bool, char, ...)
			//Console.WriteLine(parseDouble * 3);

			//int x = Convert.ToInt32(eingabe); //Convert statt int.Parse (alt)
			//Console.WriteLine(x);
			#endregion

			//Strg + K + C: Ganzen Block auskommentieren
			//Strg + K + U: Ganzen Block einkommentieren

			#region Konvertierungen
			//Explizite Konvertierung (Typecast, Cast, Casting)
			double d = 35.29;
			int i = (int) d; //Konvertierung erzwingen, da in int keine Kommastellen vorhanden sind
			float f = (float) d; //Konvertierung erzwingen, da double größer als float ist

			int z = 37;
			double implizit = z; //Konvertierung hier nicht notwendig (Implizite Konvertierung)

			string s = d.ToString(); //Beliebigen Wert zu einem String konvertieren
			#endregion

			#region Arithmetik
			int zahl1 = 4;
			int zahl2 = 9;
			Console.WriteLine(zahl1 + zahl2); //Originale Werte bleiben unverändert, nur das Ergebnis wird berechnet und ausgegeben

			zahl1 = zahl1 + zahl2; //zahl1 um zahl2 erhöhen (Langform)
			zahl1 += zahl2; //zahl1 um zahl2 erhöhen

			Console.WriteLine(zahl1 % zahl2); //Gibt den Rest der Division aus
			zahl1 %= zahl2; //Ergebnis von Modulo Berechnung Zuweisung
			Console.WriteLine(zahl1 % 2); //Prüfen, ob eine Zahl gerade ist

			zahl1 = zahl1 + 1;
			zahl1++; //Kurzform vom obigen

			zahl1 = zahl1 - 1;
			zahl1--; //Kurzform vom obigen

			double zahl3 = 34.238471982;
			//Rundungsfunktionen verändern nicht den originalen Wert
			Math.Ceiling(zahl3); //Aufrunden auf die nächste Ganze Zahl
			Math.Floor(zahl3); //Abrunden auf die nächste Ganze Zahl
			Math.Round(zahl3); //Rundet auf die nächste Zahl, bei .5 wird auf die nächste gerade Zahl gerundet
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			Math.Round(zahl3, 2); //Auf 2 Kommastellen runden

			Console.WriteLine(8 / 5); //Int-Division, da zwei Ints als Argumente (Ergebis 1 statt 1.6)
			Console.WriteLine(8.0 / 5); //Kommadivision erzwingen, eine der beiden Zahlen zu einer Kommazahl konvertieren
			Console.WriteLine(8d / 5);
			Console.WriteLine(8f / 5);
			Console.WriteLine((double) zahl1 / zahl2); //Variable zu double konvertieren mit Cast (double) 
			#endregion
		}
	}
}