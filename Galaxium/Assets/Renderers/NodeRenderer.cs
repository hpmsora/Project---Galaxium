using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeRenderer : MonoBehaviour {

	// Main Objects
	public Text Text_Name;
	public Text Text_Cost;

	// Rendering Information
	private NodeInfo NodeInformation = new NodeInfo ("Node Name", 0.0, new Vector2 (0, 0));

	// Node Utility Tools
	private NodeUtility NewNodeUtility = new NodeUtility ();

	// Initialize Node
	void Start () {
	}

	// Update Node
	void Update () {
		Text_Name.text = NodeInformation.Name;
		Text_Cost.text = NodeInformation.Cost.ToString ();
	}

	// Update Information
	public void UpdateInformation(string _NodeName, double _NodeCost, Vector2 _PositionIndex) {
		NodeInformation.Name = _NodeName;
		NodeInformation.Cost = _NodeCost;
		UpdateLocation (_PositionIndex);
	}

	// Update Location Only
	public void UpdateLocation(Vector2 _PositionIndex) {
		NodeInformation.Position = _PositionIndex;
		transform.localPosition = NewNodeUtility.NodePosition_IndexToLocal (_PositionIndex);
	}

	// Get Node Position Index
	public Vector2 GetPositionIndex() {
		return NodeInformation.Position;
	}

	// Update Node local position to 0, 0 temporarly
	public void NodeCentralize() {
		transform.localPosition = new Vector3(0, 0, 0);
	}
}
