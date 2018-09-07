using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityGroup_Button_Move : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	// Main Objects
	public GameObject GameObject_NodeUtilityGroup;

	// NodeUtilityGroup_Button_Move Information
	private Vector3 Original_Position;

	public void OnBeginDrag(PointerEventData _EventData){
		//Debug.Log ("Dragging Begin");
		Original_Position = GameObject_NodeUtilityGroup.transform.position;
		GameObject_NodeUtilityGroup.transform.position = Input.mousePosition;

		GeneratePossiblePositions ();
	}

	public void OnDrag(PointerEventData _EventData) {
		//Debug.Log ("Dragging Now");
		if (GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetIsDraggable ()) {
			GameObject_NodeUtilityGroup.transform.position = Input.mousePosition;
		} else {
			GameObject_NodeUtilityGroup.transform.localPosition = new Vector3(0, 0, 0);
		}
	}

	public void OnEndDrag(PointerEventData _EventData) {
		//Debug.Log ("Dragging Eng");
		GameObject_NodeUtilityGroup.transform.position = Original_Position;

		DestoryNodeSpace ();
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
}