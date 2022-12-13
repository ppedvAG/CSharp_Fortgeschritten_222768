namespace DelegatesEvents;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void als Rückgabewert und bis zu 16 Parametern
		action += Subtrahiere; //Methode anhängen wie bei Delegate
		action(6, 2); //Ausführen wie bei Delegate
		action?.Invoke(4, 6); //Ausführen mit Null-Check

		DoAction(5, 7, Addiere); //Das Verhalten der Methode anpassen über den Action Parameter
		DoAction(5, 8, Subtrahiere);
		DoAction(3, 4, action);

		Predicate<int> pred = CheckForZero;
		pred += CheckForOne;
		bool b = pred(1); //Ergebnis vom Predicate in Variable schreiben (hier letztes Ergebnis)
		bool? b2 = pred?.Invoke(1); //Drei mögliche Ergebnisse: true, false, null (wenn das Predicate null ist)
		bool b3 = pred?.Invoke(1) == true; //false oder null -> false sonst true

		DoPredicate(3, CheckForZero);
		DoPredicate(3, CheckForOne);
		DoPredicate(3, pred);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Rückgabetyp), bis zu 16 Parameter
		func += Dividiere;
		double d = func(5, 6); //Das letzte Ergebnis
		double? d2 = func?.Invoke(5, 9);

		DoFunc(5, 7, Multipliziere);
		DoFunc(5, 7, Dividiere);
		DoFunc(5, 7, func);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(5, 6, (x, y) => Console.WriteLine(x + y)); //Hier kein Rückgabewert möglich -> cw hat keinen Rückgabewert
		DoPredicate(5, (x) => x % 2 == 0); //Ist eine gerade Zahl als Bedingung (Lambda Expression muss einen bool zurückgeben)
		DoFunc(4, 7, (x, y) => x % y); //Anonyme Methode bei Func als Parameter benutzen
	}

	#region Action
	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	private static void DoAction(int z1, int z2, Action<int, int> action) => action?.Invoke(z1, z2);
	#endregion

	#region Predicate
	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	private static bool DoPredicate(int x, Predicate<int> pred) => pred?.Invoke(x) == true;
	#endregion

	#region Func
	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => (double) arg1 / arg2;

	private static double DoFunc(int x1, int x2, Func<int, int, double> func) => func.Invoke(x1, x2);
	#endregion
}