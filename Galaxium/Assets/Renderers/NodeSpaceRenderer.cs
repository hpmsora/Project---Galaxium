using System.Collections;
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
		if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				NewNodeUtilityGroupRenderer.SetParent (transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (false);
				NewNodeUtilityGroupRenderer.SetIsNewPosition (true);
				Debug.Log ("MOVE IN!");
			}
		} else if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				GameObject NewNodeUtilityGroup = NewNodeUtilityGroupRenderer.GetButton_Create().GetComponent<NodeUtilityGroup_Button_Create>().GetNewNodeUtilityGroup();
				NewNodeUtilityGroupRenderer = NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
				NewNodeUtilityGroupRenderer.SetParent (transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (false);
				NewNodeUtilityGroupRenderer.SetIsNewPosition (true);
				Debug.Log ("CREATE IN!");
			}
		}
	}

	// Pointer Exit
	public void OnPointerExit(PointerEventData _PointerEventData) {
		if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				NewNodeUtilityGroupRenderer.SetParent (GameObject.Find ("NodeGroup").transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (true);
				NewNodeUtilityGroupRenderer.SetIsNewPosition (false);
				Debug.Log ("MOVE OUT!");
			}
		} else if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				GameObject NewNodeUtilityGroup = NewNodeUtilityGroupRenderer.GetButton_Create().GetComponent<NodeUtilityGroup_Button_Create>().GetNewNodeUtilityGroup();
				NewNodeUtilityGroupRenderer = NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
				NewNodeUtilityGroupRenderer.SetParent (GameObject.Find ("NodeGroup").transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (true);
				NewNodeUtilityGroupRenderer.SetIsNewPosition (false);
				Debug.Log ("CREATE OUT!");
			}
		}
	}

	// Drop On
	public void OnDrop(PointerEventData _PointerEventData) {
		if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Move> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				NewNodeUtilityGroupRenderer.SetParent (GameObject.Find ("NodeGroup").transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (false);
				NewNodeUtilityGroupRenderer.UpdatePositionByIndex (NodeSpacePosition);
				Debug.Log ("MOVE DROP!");
			}
		} else if (_PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> () != null) {
			NodeUtilityGroupRenderer NewNodeUtilityGroupRenderer = _PointerEventData.pointerDrag.GetComponent<NodeUtilityGroup_Button_Create> ().GameObject_NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
			if (NewNodeUtilityGroupRenderer != null) {
				GameObject NewNodeUtilityGroup = NewNodeUtilityGroupRenderer.GetButton_Create().GetComponent<NodeUtilityGroup_Button_Create>().GetNewNodeUtilityGroup();
				NewNodeUtilityGroupRenderer = NewNodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ();
				NewNodeUtilityGroupRenderer.SetParent (GameObject.Find ("NodeGroup").transform);
				NewNodeUtilityGroupRenderer.SetIsDraggable (false);
				NewNodeUtilityGroupRenderer.UpdatePositionByIndex (NodeSpacePosition);
				Debug.Log ("CREATE DROP!");
			}
		}
	}

	// Set Position
	public void UpdatePosition(Vector2 _PositionIndex) {
		NodeSpacePosition = _PositionIndex;
		transform.localPosition = NewNodeUtility.NodePosition_IndexToLocal_withZ10 (_PositionIndex);
	}
}
