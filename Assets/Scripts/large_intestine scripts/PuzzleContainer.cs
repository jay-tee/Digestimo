using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;



[XmlRoot("puzzleCollection")]
public class PuzzleContainer  {

	[XmlArray("puzzles")]
	[XmlArrayItem("puzzle")]
	public List<Puzzle> Puzzles ;

	public static PuzzleContainer Load(string path){

		var serializer = new XmlSerializer (typeof(PuzzleContainer));
		using (var stream = new FileStream(path,FileMode.Open)) {
			return serializer.Deserialize(stream) as PuzzleContainer;
		}

	}

	public static PuzzleContainer LoadXml(XmlDocument doc){

		var serializer = new XmlSerializer (typeof(PuzzleContainer));


		MemoryStream xmlStream = new MemoryStream( );
		doc.Save( xmlStream );
		
		xmlStream.Flush();//Adjust this if you want read your data 
		xmlStream.Position = 0;
		return serializer.Deserialize(xmlStream) as PuzzleContainer;

	}
}
