namespace M007.Bauteile
{
	internal class Fenster
	{
		#region Variable + Get/Set
		private double laenge; //Felder sollten nicht von außen angreifbar sein (nur über Methoden)

		/// <summary>
		/// Gibt die Länge des Fensters zurück.
		/// </summary>
		/// <returns>Die Länge des Fenster in Meter</returns>
		public double GetLaenge()
		{
			return laenge;
		}

		/// <summary>
		/// Setzt die Länge des Fenster auf einen neuen Wert.
		/// </summary>
		/// <param name="laenge">Die neue Länge des Fensters in Meter (0 bis 10)</param>
		public void SetLaenge(double laenge)
		{
			if (laenge > 0 && laenge < 10) //Überprüfung machen bevor er gesetzt wird
				this.laenge = laenge; //this: Aus der Methode herausgreifen (nach oben greifen)
			else
				Console.WriteLine("Länge ist zu klein/groß");
		}
		#endregion

		#region Properties
		private double breite;

		public double Breite
		{
			get => breite; //{ return breite; }
			set //Hier ist auch Überprüfungscode möglich
			{
				if (value > 0 && value < 10)
					breite = value; //value: Der neue Wert (wie oben in der Set Methode -> laenge)
				else
					Console.WriteLine("Breite ist zu klein/groß");
			} //value kommt von der Main Methode bei der Zuweisung (f.Breite = 4)
		}

		//Get-Only Property
		//public double Area
		//{
		//	get
		//	{
		//		return laenge * breite;
		//	}
		//}

		//Kurzform von obigem Get-Only Property
		public double Area => laenge * breite;

		//Funktion statt Property
		public double CalcArea() => laenge * breite;

		private FensterStatus status;

		public FensterStatus Status
		{
			get => status;
			private set => status = value; //private set: nicht von außen setzbar (nur innerhalb der Klasse)
		}

		/// <summary>
		/// Eine Methode die das Fenster öffnet
		/// </summary>
		public void FensterOeffnen()
		{
			if (Status != FensterStatus.Offen)
				Status = FensterStatus.Offen; //hier private set sichtbar
			else
				Console.WriteLine("Fenster ist bereits geöffnet");
		}

		private string Farbe = "Grau"; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)

		public int Scheibenanzahl { get; set; } = 2; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)
		#endregion

		public Fenster() { }

		public Fenster(double laenge, double breite) //Konstruktor: Code der bei Erstellung (new) des Objekts ausgeführt wird
		{
			SetLaenge(laenge);
			Breite = breite;
		}

		public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite) //Konstruktoren verketten (Wenn dieser Konstruktor verwendet wird, wird der obere auch involviert)
		{
			Scheibenanzahl = scheiben;
		}

		~Fenster() //~ + Tab + Tab
		{
			Console.WriteLine($"Fenster wurde eingesammelt {GetHashCode()}");  //Wird aufgerufen wenn der Garbage Collector das Objekt einsammelt
			//GetHashCode(): Zeigt die Speicheradresse
		}

		public static int Counter;

		public static void ZaehleFenster()
		{
			Counter++;
			//Console.WriteLine(laenge); nicht möglich
		}
	}

	enum FensterStatus
	{
		Geschlossen,
		Offen,
		Gekippt
	}
}
