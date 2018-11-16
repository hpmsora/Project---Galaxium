using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityGroup_Button_Create : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	// Main GameObjects
	public GameObject GameObject_NewNode;
	public GameObject GameObject_NodeUtilityGroup;
	public GameObject GameObject_NodeConnection;

	// NodeUtilityGroup_Button_Move Information
	private Vector3 Original_Position;
	private GameObject OriginalNode;
	private GameObject NewNode;
	private GameObject NewNodeUtilityGroup;
	private GameObject NewNodeConnection;

	public void SetOriginalNode(GameObject _OriginalNode) {
		OriginalNode = _OriginalNode;
	}
	public void OnBeginDrag(PointerEventData _EventData) {
		NodeController NewNodeController = GameObject.Find("GameController").GetComponent<NodeController>();
		
		NewNodeUtilityGroup = Instantiate (GameObject_NodeUtilityGroup, transform.position, Quaternion.identity, GameObject.Find ("NodeGroup").transform) as GameObject;
		Original_Position = NewNodeUtilityGroup.transform.TransformPoint(0, 0, 0);
		NewNodeUtilityGroup.name = "New Node Utility Group";
		ClearNode ();
		CreateNewNode ();
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetNewNode (NewNode);
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsDraggable (true);
		NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().SetIsNewPosition (false);
		NewNodeConnection = NewNodeController.CreateNodeConnection(OriginalNode, NewNode, GameObject_NodeConnection, Color.red);
		GeneratePossiblePositions ();
	}

	public void OnDrag(PointerEventData _EventData) {
		if (NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetIsDraggable ()) {
			NewNodeUtilityGroup.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Original_Position.z));
		} else {
			NewNodeUtilityGroup.transform.localPosition = new Vector3(0, 0, 0);
		}
	}

	public void OnEndDrag(PointerEventData _EventData) {
		if (!NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetIsNewPosition ()) {
			Destroy (NewNodeUtilityGroup);
			Destroy (NewNodeConnection);
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
