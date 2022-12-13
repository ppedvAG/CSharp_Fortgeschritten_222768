namespace M008
{
	class AccessModifier //Klassen und Member ohne Modifier sind internal
	{
		public string Name { get; set; } //Überall sichtbar, auch außerhalb vom Projekt

		private int Alter { get; set; } //Kann nur innerhalb dieser Klasse gesehen werden

		internal string Wohnort { get; set; } //Überall sichtbar, außer außerhalb vom Projekt

		protected string Lieblingsfarbe { get; set; } //Nur in der Klasse und in Unterklassen sichtbar (auch außerhalb)

		protected internal string Lieblingsnahrung { get; set; } //Kann im Projekt überall (durch internal) und in Unterklassen außerhalb vom Projekt (protected)

		protected private DateTime Geburtsdatum { get; set; } //Kann nur in dieser Klasse und in Unterklassen nur im Projekt gesehen werden
	}
}
