using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour {

	// Mainscene Objects
	//public GameObject MainGameController;

	// Temporary Fixed Game Information
	private GameObject NewNodeUtility;
	private GameObject NewNode;

	// Create uility tools for each node
	public void ShowingNodeUtility(GameObject _GameObject_NodeUtility, GameObject _NodeGroup) {
		Debug.Log (_GameObject_NodeUtility.name);
		Vector3 DefaultNodeUtilityLocation = new Vector3 (0, 0, 0);
		GameObject[] AllNodes = GetAllNodeGameObjects ();

		foreach (GameObject EachAllNode in AllNodes) {
			Debug.Log (EachAllNode.transform.localPosition);
			NewNodeUtility = Instantiate (_GameObject_NodeUtility, DefaultNodeUtilityLocation, Quaternion.identity, _NodeGroup.transform) as GameObject;
			NewNodeUtility.GetComponent<NodeUtilityGroupRenderer> ().UpdateInformation (EachAllNode.transform.localPosition);
			NewNodeUtility.name = EachAllNode.name + "UtilityGroup";
			EachAllNode.transform.parent = NewNodeUtility.transform;
			EachAllNode.GetComponent<NodeRenderer> ().NodeCentralize ();
		}
	}

	// Destroy uility tools on all nodes
	public void DestoryNodeUtility(GameObject _NodeGroup) {
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
