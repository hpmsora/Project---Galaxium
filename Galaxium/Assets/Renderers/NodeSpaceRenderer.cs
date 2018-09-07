﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeSpaceRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler {

	// Node Space Information
	private Vector2 NodeSpacePosition;

	// Node Utility Tools
	private NodeUtility NewNodeUtility = new NodeUtility ();

	// Initialization
	void Start() {
	}

	// Pointer Enter
	public void OnPointerEnter(PointerEventData _PointerEventData) {
		NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer>();
		if (NewNodeUtilityGroupRenderer != null) {
			NewNodeUtilityGroupRenderer.SetParent (transform);
			NewNodeUtilityGroupRenderer.SetIsDraggable (false);
			Debug.Log ("IN");
		}
		Debug.Log (_PointerEventData.pointerDrag);
	}

	// Pointer Exit
	public void OnPointerExit(PointerEventData _PointerEventData) {
		NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer>();
		if (NewNodeUtilityGroupRenderer != null) {
			NewNodeUtilityGroupRenderer.SetParent (GameObject.Find("NodeGroup").transform);
			NewNodeUtilityGroupRenderer.SetIsDraggable (true);
			Debug.Log ("OUT");
		}
	}

	// Drop On
	public void OnDrop(PointerEventData _PointerEventData) {
		Debug.Log ("Drop!");
	}

	// Set Position
	public void UpdatePosition(Vector2 _PositionIndex) {
		NodeSpacePosition = _PositionIndex;
		transform.localPosition = NewNodeUtility.NodePosition_IndexToLocal (_PositionIndex);
	}
}