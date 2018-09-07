using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityGroupRenderer : MonoBehaviour {

	// Main Objects
	public Button Button_Move;
	public Button Button_Create;
	public GameObject GameObject_NodeSpace;

	// Rendering Information
	private bool isDraggable = true;
	private Vector3 RelativeLocation = new Vector3(0, 0, 0);
	private GameObject NewNode;
	private GameObject NewNodeSpace;

	// Initialize Node
	void Start () {
	}
	
	// Update Node
	void Update () {
	}

	// Get Draggable Variable Value
	public bool GetIsDraggable() {
		return isDraggable;
	}

	// Set Draggable Variable Value
	public void SetIsDraggable(bool _isDraggable) {
		isDraggable = _isDraggable;
	}

	// Set Parent GameObject
	public void SetParent(Transform _Parent) {
		transform.SetParent (_Parent);
	}

	// Update Position Information
	public void UpdateInformation(Vector3 _RelativeLocation, GameObject _NewNode) {
		RelativeLocation = _RelativeLocation;
		transform.localPosition = RelativeLocation;
		NewNode = _NewNode;
	}

	// Get All Possible Position
	// Vector3 <X, Y, 0 or 1 (0 = Empty, 1 = Occupied)>
	public List<Vector3> GetAllPossiblePosition() {
		Vector2 NodePositionIndex = NewNode.GetComponent<NodeRenderer>().GetPositionIndex();
		GameObject[] AllNodes = GameObject.FindGameObjectsWithTag ("Node");
		List<Vector2> OccupiedNodePositionIndexs = new List<Vector2> ();
		List<Vector3> AllPossibleNodePositionIndexs = new List<Vector3> ();

		foreach (GameObject EachAllNode in AllNodes) {
			OccupiedNodePositionIndexs.Add (EachAllNode.GetComponent<NodeRenderer> ().GetPositionIndex ());
		}

		Vector2 PossibleNodePositionIndex_Limit_Lower = NodePositionIndex - new Vector2 (GameConstants.Node_ExpensionLevel, GameConstants.Node_ExpensionLevel);
		Vector2 PossibleNodePositionIndex_Limit_Upper = NodePositionIndex + new Vector2 (GameConstants.Node_ExpensionLevel, GameConstants.Node_ExpensionLevel);
		Vector2 NewPossiblePositionIndex = new Vector2 (0, 0);

		for (int PositionIndex_X = (int)PossibleNodePositionIndex_Limit_Lower.x; PositionIndex_X <= (int)PossibleNodePositionIndex_Limit_Upper.x; PositionIndex_X++) {
			for (int PositionIndex_Y = (int)PossibleNodePositionIndex_Limit_Lower.y; PositionIndex_Y <= (int)PossibleNodePositionIndex_Limit_Upper.y; PositionIndex_Y++) {
				NewPossiblePositionIndex = new Vector2 (PositionIndex_X, PositionIndex_Y);
				if (NewPossiblePositionIndex != NodePositionIndex) {
					if (OccupiedNodePositionIndexs.Contains (NewPossiblePositionIndex)) {
						AllPossibleNodePositionIndexs.Add (new Vector3 (PositionIndex_X, PositionIndex_Y, 1));
					} else {
						AllPossibleNodePositionIndexs.Add (new Vector3 (PositionIndex_X, PositionIndex_Y, 0));
					}
				}
			}
		}

		return AllPossibleNodePositionIndexs;
	}

	// Create Node Spaces
	public void CreateNodeSpaces(List<Vector3> _PossibleNodePositionIndexs) {
		Vector3 DefaultNodeSpacePosition = new Vector3 (0, 0, 0);
		GameObject NodeGroup = GameObject.Find ("NodeGroup");

		foreach (Vector3 EachPossibleNodePositionIndex in _PossibleNodePositionIndexs) {
			NewNodeSpace = Instantiate (GameObject_NodeSpace, DefaultNodeSpacePosition, Quaternion.identity, NodeGroup.transform) as GameObject;
			NewNodeSpace.GetComponent<NodeSpaceRenderer> ().UpdatePosition (new Vector2 (EachPossibleNodePositionIndex.x, EachPossibleNodePositionIndex.y));
			NewNodeSpace.name = EachPossibleNodePositionIndex.x.ToString () + " " + EachPossibleNodePositionIndex.y.ToString () + " NodeSpace";
		}
	}
}