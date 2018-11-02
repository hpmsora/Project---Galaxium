using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeInfo {

	// Constructor
	public NodeInfo(string _Name, double _LaborCost, Vector2 _Position) {
		Name = _Name;
		LaborCost = _LaborCost;
		Position = _Position;
		ChildrenList = new List<GameObject>();
	}

	// Name (String)
	public string Name { get; set; }

	// Labor Cost (Double)
	public double LaborCost { get; set; }

	// Position (Vector2)
	public Vector2 Position { get; set; }

	// Children List (List<GameObject>)
	public List<GameObject> ChildrenList { get; set; }
}
