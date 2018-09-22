using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityGroup_Button_Create : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	// Main Objects
	public GameObject GameObject_NewNode;
	public GameObject GameObject_NodeUtilityGroup;
	public GameObject GameObject_NewNodeUtilityGroup;

	// NodeUtilityGroup_Button_Move Information
	private Vector3 Original_Position;
	private GameObject NewNode;
	private GameObject NewNodeUtilityGroup;

	public void OnBeginDrag(PointerEventData _EventData){
		Original_Position = GameObject_NodeUtilityGroup.transform.position;

		NewNodeUtilityGroup = Instantiate (GameObject_NewNodeUtilityGroup, transform.position, Quaternion.identity, GameObject.Find ("NodeGroup").transform) as GameObject;
		NewNodeUtilityGroup.name = "New Node Utility Group";
		ClearNode ();
		CreateNewNode ();
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetNewNode (NewNode);
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsDraggable (true);
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsNewPosition (false);
		GeneratePossiblePositions ();
	}

	public void OnDrag(PointerEventData _EventData) {
		if (NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetIsDraggable ()) {
			NewNodeUtilityGroup.transform.position = Input.mousePosition;
		} else {
			NewNodeUtilityGroup.transform.localPosition = new Vector3(0, 0, 0);
		}
	}

	public void OnEndDrag(PointerEventData _EventData) {
		if (!NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetIsNewPosition ()) {
			NewNodeUtilityGroup.transform.position = Original_Position;
		}
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsDraggable (false);
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsNewPosition (false);

		DestoryNodeSpace ();
	}

	// Get New Node Utility Group
	public GameObject GetNewNodeUtilityGroup() {
		return NewNodeUtilityGroup;
	}

	// Generate New Possible Positions
	void GeneratePossiblePositions() {
		List<Vector3> AllPossibleNodePositionIndexs = GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetAllPossiblePosition ();

		GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().CreateNodeSpaces (AllPossibleNodePositionIndexs);
	}

	// Destroy All Node Space GameObject
	void DestoryNodeSpace() {
		GameObject[] AllNodeSpaces = GameObject.FindGameObjectsWithTag ("NodeSpace");

		foreach (GameObject EachAllNodeSpaces in AllNodeSpaces) {
			Destroy (EachAllNodeSpaces);
		}
	}

	// Find Node Child and Destroy
	void ClearNode() {
		foreach (Transform EachTransform in NewNodeUtilityGroup.transform) {
			if (EachTransform.tag == "Node") {
				EachTransform.GetComponent<NodeRenderer> ().DestoryNode ();
			}
		}
	}

	// Create New Npde
	void CreateNewNode() {
		NewNode = Instantiate (GameObject_NewNode, new Vector3 (0, 0, 0), Quaternion.identity, NewNodeUtilityGroup.transform) as GameObject;
		NewNode.GetComponent<NodeRenderer> ().NodeCentralize ();
		NewNode.name = "New Node";
	}
}
