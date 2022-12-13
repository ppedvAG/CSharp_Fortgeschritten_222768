using M006.Bauteile; //mit Using andere Namespaces importieren

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fenster f = new Fenster(); //Fenster Objekt erstellen mit dem new Keyword
			f.SetLaenge(4); //Länge setzen über Set-Methode
			f.Breite = 4; //Breite setzen über Property
			f.FensterOeffnen();

			Fenster f2 = new Fenster(2, 5, 2);

			Raum r = new Raum();
			r.Tuer = new Tuere();
			r.Fenster[0] = f;
			r.Fenster[1] = f2;

			//Console -> System
			//File -> System.IO
			//HttpClient -> System.Net.Http
		}
	}
}