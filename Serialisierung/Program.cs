using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//Streams();

		//SystemJson();

		//NewtonsoftJson();

		//Xml();

		//Binary();
	}

	public static void Streams()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		StreamWriter sw = new StreamWriter(filePath); //Stream öffnen auf Pfad
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		sw.Close(); //Stream unbedingt schließen

		using (StreamWriter sw2 = new(filePath)) //Using-Block: schließt den Stream am Ende des Blocks (bei })
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		}

		//using StreamWriter sw3 = new(filePath); //Using-Statement: schließt den Stream am Ende der Methode
		//sw3.WriteLine("Test1");
		//sw3.WriteLine("Test2");
		//sw3.WriteLine("Test3");

		using StreamReader sr = new(filePath);
		string full = sr.ReadToEnd();
		List<string> lines = full.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
	}

	public static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//JsonSerializerOptions options = new(); //Einstellungen für das Serialisieren/Deserialisieren angeben
		//options.WriteIndented = true; //Json schön schreiben
		//options.ReferenceHandler = ReferenceHandler.IgnoreCycles; //Zyklen ignorieren (z.B.: Baumstrukturen)

		//string json = JsonSerializer.Serialize(fahrzeuge, options); //JsonSerializer: Klasse zum Umwandeln von Objekten <-> Json
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options); //Deserialisierung kann in einen beliebigen Listentypen passieren

		////Json durchgehen bei dem keine vordefinierten Objekte existieren (z.B.: Webschnittstelle)
		//JsonDocument doc = JsonDocument.Parse(json); //Json String zu einem JsonDocument konvertieren
		//JsonElement.ArrayEnumerator ae = doc.RootElement.EnumerateArray(); //Json Enumerieren
		//foreach (JsonElement je in ae)
		//{
		//	Console.WriteLine(je.GetProperty("MaxV").GetInt32()); //Einzelne Werte aus dem Json entnehmen

		//	Fahrzeug f = je.Deserialize<Fahrzeug>(); //Deserialize Methode auf dem JsonElement wenn ich das Element kenne
		//	Console.WriteLine(f.MaxV);
		//}
	}

	public static void NewtonsoftJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		JsonSerializerSettings settings = new();
		//settings.Formatting = Formatting.Indented;
		settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

		string json = JsonConvert.SerializeObject(fahrzeuge, settings); //JsonConvert = JsonSerializer
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings);

		JToken doc = JToken.Parse(readJson);
		foreach (JToken element in doc)
		{
			Console.WriteLine(element["MaxV"].Value<int>());

			Fahrzeug f = JsonConvert.DeserializeObject<Fahrzeug>(element.ToString()); //Keine direkte Methode
			Console.WriteLine(f.MaxV);
		}
	}

	public static void Xml()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType()); //XmlSerializer: braucht ein Objekt und einen Typen zum Serialisieren
		using (FileStream fs = new FileStream(filePath, FileMode.Create)) //Xml Serialisierung braucht immer direkt ein File
			xml.Serialize(fs, fahrzeuge);

		using (FileStream fs = new FileStream(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(fs) as List<Fahrzeug>;
			Console.WriteLine(readFzg.Count);
		}

		XmlDocument doc = new XmlDocument();
		doc.LoadXml(File.ReadAllText(filePath));
		foreach (XmlNode node in doc.ChildNodes[1])
		{
			Console.WriteLine(node.ChildNodes.OfType<XmlNode>().First(e => e.Name == "MaxV").InnerText);
		}
	}

	public static void Binary()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad
		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		BinaryFormatter formatter = new();
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
			formatter.Serialize(fs, fahrzeuge);

		using (FileStream fs = new(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = formatter.Deserialize(fs) as List<Fahrzeug>;
		}
	}
}

[Serializable]
public class Fahrzeug
{
	[JsonIgnore] //Ignoriere dieses Feld beim schreiben (bei beiden Frameworks)
	[JsonProperty("Identifier")] //Feld umbenennen (Newtonsoft.Json)
	//[JsonPropertName("Identifier")] //Feld umbenennen (System.Text.Json)
	public int ID { get; set; }

	[field: NonSerialized] //BinaryIgnore
	public int MaxV { get; set; }

	[XmlIgnore]
	[XmlElement("Marke")] //Umbenennen
	[XmlAttribute] //Marke zu Attribut konvertieren: <Marke>BMW</Marke> -> <Fahrzeug Marke="BMW">...</Fahrzeug>
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int ID, int MaxV, FahrzeugMarke Marke)
	{
		this.ID = ID;
		this.MaxV = MaxV;
		this.Marke = Marke;
	}

	public Fahrzeug()
	{
		//für XmlSerializer
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }