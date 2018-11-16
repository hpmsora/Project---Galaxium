﻿using System.Collections;
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

	// Getting all node gameobjects
	GameObject[] GetAllNodeGameObjects() {
		return GameObject.FindGameObjectsWithTag ("Node");
	}

	// Getting all node utility gameobjects
	GameObject[] GetAllNodeUtilityGameObjects() {
		return GameObject.FindGameObjectsWithTag ("NodeUtility");
	}

	//-----------------------------------------------------------------------
	// NODE CONNECTION CONTROLLER
	// Generate node connection
	public GameObject CreateNodeConnection(GameObject _Node_Parent, GameObject _Node_Child, GameObject _NodeConnection, Color _Color) {
		Vector3 Node_Parent_Position = _Node_Parent.transform.position;
		Vector3 Node_Child_Position = _Node_Child.transform.position;
		string Parent_Name = _Node_Parent.name;
		string Child_Name = _Node_Child.name;
		Node_Parent_Position.z = 90;
		Node_Child_Position.z = 90;

		NewNodeConnection = Instantiate(_NodeConnection, Node_Parent_Position, Quaternion.identity, GameObject.Find("NodeConnectionGroup").transform);
		NewNodeConnection.name = Parent_Name + " <> " + Child_Name;
		NewNodeConnection.GetComponent<NodeConnectionRenderer>().SetParentAndChild(_Node_Parent, _Node_Child);
		NewNodeConnection.GetComponent<NodeConnectionRenderer>().SetColor(_Color);
		
		return NewNodeConnection;
	}

	public void GetActiveNodeConnection(string _NodeName) {
		GameObject[] AllNodeConnections = GetAllNodeConnections();
	}

	GameObject[] GetAllNodeConnections() {
		return GameObject.FindGameObjectsWithTag("NodeConnection");
	}
}
