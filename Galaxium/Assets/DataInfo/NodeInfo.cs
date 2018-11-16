using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeInfo {

	// Constructor
	public NodeInfo(string _Name, double _LaborCost, Vector2 _Position, int _Resource_Number) {
		Name = _Name;
		LaborCost = _LaborCost;
		Position = _Position;
		ChildrenList = new List<GameObject>();
		ResourceList = new double[_Resource_Number];
	}

	// Name (String)
	public string Name { get; set; }

	// Labor Cost (Double)
	public double LaborCost { get; set; }

	// Position (Vector2)
	public Vector2 Position { get; set; }

	// Children List (List<GameObject>)
	public List<GameObject> ChildrenList { get; set; }

	// Node Resource Information
	public double[] ResourceList { get; set; }
}
