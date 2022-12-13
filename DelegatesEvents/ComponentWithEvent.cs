namespace DelegatesEvents;

internal class ComponentWithEvent
{
	static void Main(string[] args)
	{
		Component comp = new();
		comp.ProcessCompleted += () => Console.WriteLine("Prozess fertig"); //Anonyme Methode ohne Parameter mit () => 
		comp.Progress += (x) => Console.WriteLine($"Fortschritt: {x}"); //Action mit einem Parameter (x)
		comp.StartProcess();
	}
}

public class Component
{
	public event Action ProcessCompleted; //Action als Delegate statt EventHandler

	public event Action<int> Progress; //Action mit einem Parameter

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			Progress(i);
		}
		ProcessCompleted();
	}
}