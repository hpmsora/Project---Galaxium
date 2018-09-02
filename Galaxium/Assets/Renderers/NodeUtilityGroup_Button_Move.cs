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
		Debug.Log ("Dragging Begin");
		Original_Position = GameObject_NodeUtilityGroup.transform.position;
		GameObject_NodeUtilityGroup.transform.position = Input.mousePosition;
	}

	public void OnDrag(PointerEventData _EventData) {
		Debug.Log ("Dragging Now");
		GameObject_NodeUtilityGroup.transform.position = Input.mousePosition;

	}

	public void OnEndDrag(PointerEventData _EventData) {
		Debug.Log ("Dragging Eng");
		GameObject_NodeUtilityGroup.transform.position = Original_Position;
	}
}