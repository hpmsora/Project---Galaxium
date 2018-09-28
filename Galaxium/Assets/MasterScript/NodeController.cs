using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour {

	// Temporary Fixed Game Information
	private GameObject NewNodeUtilityGroup;
	private GameObject NewNode;

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
			NewNodePositionIndex = EachAllNode.GetComponent<NodeRenderer> ().GetPositionIndex ();
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
}
