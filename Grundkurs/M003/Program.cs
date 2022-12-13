namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			//Array: Variable die mehrere Werte halten kann
			int[] zahlen; //Arrayvariable mit [] nach Typ (<Typ>[])
			zahlen = new int[10]; //Array mit Länge 10 (0-9)
			zahlen[2] = 20; //Stelle angreifen mit [<Index>]
			Console.WriteLine(zahlen[2]);

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch (5)
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise (wie oben, nur kürzer)
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			Console.WriteLine(zahlen.Length); //Größe des Arrays (10)

			Console.WriteLine(zahlenDirekt.Contains(4)); //true
			Console.WriteLine(zahlenDirekt.Contains(8)); //false

			//Zwei-dimensionales Array: braucht 2 Größen bei Initialisierung
			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Deklaration mit Beistrich in der Klammer
			zweiDArray[1, 1] = 5;
			Console.WriteLine(zweiDArray[1, 1]);

			zweiDArray = new[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

			Console.WriteLine(zweiDArray.Length); //3x3 Plätze = 9
			Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen: 2
			Console.WriteLine(zweiDArray.GetLength(0)); //Länge der nullten Dimension: 3
			Console.WriteLine(zweiDArray.GetLength(1)); //Länge der ersten Dimension: 3
			#endregion

			#region Bedingungen
			int zahl1 = 5;
			int zahl2 = 7;

			if (zahl1 == zahl2)
			{
				//Code wenn beide Zahlen gleich
			}

			if (zahl1 < zahl2)
			{
				//Wenn die erste Zahl kleiner ist als die zweite
			}

			if (zahl1 != zahl2)
			{
				//Ungleich !=
			}

			bool b1 = true;
			bool b2 = false;
			if (b1 && b2) //und
			{
				//Wenn beide true sind
			}

			if (b1 || b2) //oder
			{
				//Wenn eins von beiden true ist
			}

			if (b1 ^ b2)
			{
				//Wenn b1 und b2 unterschiedlich sind
			}

			b1 = !b1; //boolean invertieren auf klassischem Wege
			b1 ^= true; //boolean invertieren über xor
			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean;
			//App.MainWindow.Button.Boolean ^= true;

			if (!b1)
			{
				//Wenn nicht b1
			}

			if (zahl1 < zahl2)
			{
				//Wenn zahl1 kleiner zahl2
			}
			else
			{
				//Wenn zahl1 nicht kleiner zahl2 -> wenn zahl1 größer oder gleich zahl2
			}

			if (zahl1 < zahl2)
			{

			}
			else if (zahl1 != zahl2)
			{

			}
			else
			{

			}

			//else if für den Compiler
			//if (zahl1 < zahl2)
			//{

			//}
			//else
			//{
			//	if (zahl1 != zahl2)
			//	{

			//	}
			//	else
			//	{

			//	}
			//}

			if (zahl1 != zahl2) //Bei einzeiligen ifs können die Klammern weggelassen werden
				Console.WriteLine("Die Zahlen sind ungleich");
			else //Bei else auch
				Console.WriteLine("Die Zahlen sind gleich");

			if (zahlen.Contains(3))
			{
				//Zahlen enthält 3
			}

			//Fragezeichen Operator (?, :) ? ist if, : ist else
			//Braucht immer ein else
			Console.WriteLine(zahl1 != zahl2 ? "Die Zahl sind ungleich" : "Die Zahlen sind gleich");
			#endregion
		}
	}
}