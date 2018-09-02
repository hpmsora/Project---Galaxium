using UnityEngine;

public class NodeInfo {

	// Constructor
	public NodeInfo(string _Name, double _Cost, Vector2 _Position) {
		Name = _Name;
		Cost = _Cost;
		Position = _Position;
	}

	// Name (String)
	public string Name { get; set; }

	// Cost (Float)
	public double Cost { get; set; }

	// Position (Vector2)
	public Vector2 Position { get; set; }
}
