using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour {

	// Temporary Fixed Game Information
	private GameObject NewNodeUtilityGroup;
	private GameObject NewNode;
	private GameObject NewNodeConnection;

	// Create New Node
	public GameObject CreateNewNode(GameObject _GameObject_Node, string _NodeName, double _Cost, Vector3 _RelativeLocation) {
		NewNode = Instantiate (_GameObject_Node, new Vector3 (0, 0, 0), Quaternion.identity, GameObject.Find("NodeGroup").transform) as GameObject;
		NewNode.GetComponent<NodeRenderer> ().UpdateInformation (_NodeName, _Cost, _RelativeLocation);
		NewNode.name = _NodeName;

		return NewNode;
	}

	// Create uility tools for each node
	public void ShowingNodeUtilityGroup(GameObject _GameObject_NodeUtilityGroup, GameObject _NodeGroup) {
		Vector3 DefaultNodeUtilityLocation = new Vector3 (0, 0, 0);
		GameObject[] AllNodes = GetAllNodeGameObjects ();

		foreach (GameObject EachAllNode in AllNodes) {
			NewNodeUtilityGroup = Instantiate (_GameObject_NodeUtilityGroup, DefaultNodeUtilityLocation, Quaternion.identity, _NodeGroup.transform) as GameObject;
			NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().UpdateInformation (EachAllNode.transform.localPosition, EachAllNode);
			NewNodeUtilityGroup.name = EachAllNode.name + "UtilityGroup";
			EachAllNode.transform.parent = NewNodeUtilityGroup.transform;
			EachAllNode.GetComponent<NodeRenderer> ().NodeCentralize ();
		}
	}

	// Destroy uility tools on all nodes
	public void DestoryNodeUtilityGroup(GameObject _NodeGroup) {
		GameObject[] AllNodeUtilities = GetAllNodeUtilityGameObjects ();
		GameObject[] AllNodes = GetAllNodeGameObjects ();
		Vector2 NewNodePositionIndex = new Vector2 (0, 0);

		foreach (GameObject EachAllNode in AllNodes) {
			NewNodePositionIndex = EachAllNode.GetComponent<NodeRenderer> ().GetNodePositionIndex ();
			EachAllNode.transform.parent = _NodeGroup.transform;
			EachAllNode.GetComponent<NodeRenderer> ().UpdateLocation (NewNodePositionIndex);
		}

		foreach (GameObject EachAllNodeUtilities in AllNodeUtilities) {
			Destroy (EachAllNodeUtilities);
		}
	}

	// Generate node connection
	public void CreateNodeConnection(GameObject _Node_1, GameObject _Node_2, GameObject _NodeConnection, Color _Color) {
		Vector3 Node_1_Position = _Node_1.transform.position;
		Vector3 Node_2_Position = _Node_2.transform.position;
		Node_1_Position.z = 90;
		Node_2_Position.z = 90;

		NewNodeConnection = Instantiate(_NodeConnection, Node_1_Position, Quaternion.identity, GameObject.Find("NodeConnectionGroup").transform);
		NewNodeConnection.name = "Test";
		LineRenderer NewLineRenderer = NewNodeConnection.GetComponent<LineRenderer>();
		NewLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		NewLineRenderer.material.color = Color.red;
		NewLineRenderer.SetColors(_Color, _Color);
		NewLineRenderer.widthMultiplier = GameConstants.NodeConnection_Width;
		NewLineRenderer.SetPosition(0, Node_1_Position);
		NewLineRenderer.SetPosition(1, Node_2_Position);
	}

	// Getting all node gameobjects
	GameObject[] GetAllNodeGameObjects() {
		return GameObject.FindGameObjectsWithTag ("Node");
	}

	// Getting all node utility gameobjects
	GameObject[] GetAllNodeUtilityGameObjects() {
		return GameObject.FindGameObjectsWithTag ("NodeUtility");
	}
}
