namespace M009;

public abstract class Bauteil //abstract: Stellt eine Struktur dar
{
	public double Laenge { get; set; }

	public double Breite { get; set; }

	public abstract double CalcArea(); //Abstrakte Methoden haben keinen Body, müssen in der Unterklasse implementiert
}
