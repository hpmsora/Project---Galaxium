using UnityEngine;

public class NodeInfo {

	// Constructor
	public NodeInfo(string _Name, double _LaborCost, Vector2 _Position) {
		Name = _Name;
		LaborCost = _LaborCost;
		Position = _Position;
	}

	// Name (String)
	public string Name { get; set; }

	// Labor Cost (Double)
	public double LaborCost { get; set; }

	// Position (Vector2)
	public Vector2 Position { get; set; }
}
