﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeRenderer : MonoBehaviour {

	// Main Objects
	public Text Text_Name;
	public Text Text_Cost;

	// Rendering Information
	private NodeInfo NodeInformation = new NodeInfo ("Node Name", 0.0, new Vector2 (0, 0), GameConstants.Resource_Number);

	// Node Utility Tools
	private NodeUtility NewNodeUtility = new NodeUtility ();

	// Initialize Node
	void Start () {
	}

	// Update Node
	void Update () {
		Text_Name.text = NodeInformation.Name;
		Text_Cost.text = NodeInformation.LaborCost.ToString ();
	}

	// Update Information
	public void UpdateInformation(string _NodeName, double _NodeLaborCost, Vector2 _PositionIndex) {
		NodeInformation.Name = _NodeName;
		NodeInformation.LaborCost = _NodeLaborCost;
		UpdateLocation (_PositionIndex);
	}

	// Update Location Only without Moving
	public void UpdateLocationWithoutMoving(Vector2 _PositionIndex) {
		NodeInformation.Position = _PositionIndex;
	}

	// Update Location Only
	public void UpdateLocation(Vector2 _PositionIndex) {
		NodeInformation.Position = _PositionIndex;
		transform.localPosition = NewNodeUtility.NodePosition_IndexToLocal (_PositionIndex);
	}

	// Get Node Name
	public string GetNodeName() {
		return NodeInformation.Name;
	}

	// Set Node Name
	public void SetNodeName(string _NodeName) {
		NodeInformation.Name = _NodeName;
	}

	// Get Node Labor Cost
	public double GetNodeLaborCost() {
		return NodeInformation.LaborCost;
	}

	// Set Node Labor Cost
	public void SetNodeLaborCost(double _NodeLaborCost) {
		NodeInformation.LaborCost = _NodeLaborCost;
	}

	// Get Node Position Index
	public Vector2 GetNodePositionIndex() {
		return NodeInformation.Position;
	}

	// Get Node Children List
	public List<GameObject> GetNodeChildrenList() {
		return NodeInformation.ChildrenList;
	}

	// Set Node Children List
	public void SetNodeChildrenList(List<GameObject> _NodeChildrenList) {
		NodeInformation.ChildrenList = _NodeChildrenList;
	}

	// Get Node Resource List
	public double[] GetNodeResourceList() {
		return NodeInformation.ResourceList;
	}

	// Add Node Child
	public void AddNodeChild(GameObject _NodeChild) {
		NodeInformation.ChildrenList.Add(_NodeChild);
	}

	// Update Node local position to 0, 0 temporarly
	public void NodeCentralize() {
		transform.localPosition = new Vector3(0, 0, 0);
	}

	// Reset Node
	public void ResetNode() {
		NodeInformation = new NodeInfo ("Node Name", 0.0, new Vector2 (0, 0), 0);
	}

	// Destory Node
	public void DestoryNode() {
		Destroy (gameObject);
	}
}
