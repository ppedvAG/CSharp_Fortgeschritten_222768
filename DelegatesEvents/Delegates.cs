namespace DelegatesEvents
{
	internal class Delegates
	{
		public delegate void Vorstellungen(string name); //Definition von Delegate, speichert Referenzen auf Methoden, können zu Laufzeit hinzugefügt und weggenommen werden

		static void Main(string[] args)
		{
			Vorstellungen v = new Vorstellungen(VorstellungDE); //Variablendeklaration + Erstellung mit Initialmethode
			v("Max"); //Delegate ausführen

			v += VorstellungEN; //Weitere Methode anhängen
			v("Max"); //Methoden werden in der Reihenfolge ausgeführt in der sie angehängt werden

			v += VorstellungEN;
			v += VorstellungEN;
			v += VorstellungEN; //Methoden können mehrmals angehängt werden
			v("max");

			v -= VorstellungDE; //Methode abnehmen
			v -= VorstellungDE;
			v -= VorstellungDE; //Methode die nicht angehängt ist, kann nicht abgenommen werden -> nichts passiert
			v("Max");

			v -= VorstellungEN;
			v -= VorstellungEN;
			v -= VorstellungEN; //Delegate ist ab hier null
			v -= VorstellungEN;
			v -= VorstellungEN;
			//v("Max"); //Exception

			if (v is not null)
				v("Max");

			//v.Invoke("Max"); //Delegate ausführen wie v(Name)
			v?.Invoke("Max"); //Wenn v nicht null aus, dann Invoke, sonst nichts

			List<int> test = null;
			test?.Add(1);

			v = null; //Delegate entleeren

			foreach (Delegate dg in v.GetInvocationList()) //Delegate anschauen
			{
				Console.WriteLine(dg.Method.Name); //Alle Methoden ausgeben
			}
		}

		static void VorstellungDE(string name)
		{
			Console.WriteLine($"Mein Name ist {name}");
		}

		static void VorstellungEN(string name)
		{
			Console.WriteLine($"Hello my name is {name}");
		}
	}
}