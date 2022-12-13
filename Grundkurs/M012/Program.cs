namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //Exceptions die nicht gefangen wurden loggen
		//throw new Exception("Test");

		try //Codeblock markieren + Rechtsklick -> Surround with -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exception sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException
			if (x == 0)
				throw new TestException("Die eingegebene Zahl ist 0", "Fehler"); //(beliebige) Exception werfen
		}
		catch (FormatException e) //Keine Zahl eingegeben (Buchstaben)
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(e.Message); //Die Nachricht der Exception (hier Input string was not in a correct format)
			Console.WriteLine(e.StackTrace); //Wo ist die Exception im Code aufgetreten?
		}
		catch (OverflowException e) //Zahl zu klein/groß
		{
			Console.WriteLine($"Zahl ist außerhalb des gültigen Bereichs. Gültiger Bereich: {int.MinValue} bis {int.MaxValue}");
			Console.WriteLine(e.Message);
		}
		catch (TestException e)
		{
			e.Test(); //Test Methode von unten benutzen
			Console.WriteLine(e.Status);
			Console.WriteLine(e.Message);
		}
		catch (Exception e) //Alle anderen Fehler abhandeln
		{
			Console.WriteLine($"Ein anderer Fehler ist aufgetreten: {e.Message}");
			throw; //Fataler Fehler
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception; //(Exception) e.ExceptionObject
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception //Eigene Exception muss von einer Exception Klasse erben
{
	public string Status;

	public TestException(string? message, string status) : base(message)
	{
		Status = status;
	}

	public void Test() => Console.WriteLine("Die Exception ist aufgetreten");
}