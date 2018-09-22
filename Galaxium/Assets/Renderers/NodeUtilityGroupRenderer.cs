using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityGroupRenderer : MonoBehaviour {

	// Main Objects
	public Button Button_Move;
	public Button Button_Create;
	public Button Button_Setting;
	public Button Button_Destroy;

	public GameObject GameObject_NodeSpace;

	// Rendering Information
	private bool isDraggable = true;
	private bool isNewPosition = false;
	private Vector3 RelativePosition = new Vector3(0, 0, 0);
	private GameObject NewNode;
	private GameObject NewNodeSpace;

	// Node Utility Tools
	private NodeUtility NewNodeUtility = new NodeUtility ();

	// Initialization
	void Start() {
		Button button_Setting = Button_Setting.GetComponent<Button> ();
		Button button_Destroy = Button_Destroy.GetComponent<Button> ();

		button_Setting.onClick.AddListener (Button_Setting_Function);
		button_Destroy.onClick.AddListener (Button_Destroy_Function);
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

	// Get New Position Variable Value
	public bool GetIsNewPosition() {
		return isNewPosition;
	}

	// Set New Position Variable Value
	public void SetIsNewPosition(bool _isNewPosition) {
		isNewPosition = _isNewPosition;
	}

	// Set Parent GameObject
	public void SetParent(Transform _Parent) {
		transform.SetParent (_Parent);
	}

	// Set New Node Variable
	public void SetNewNode(GameObject _NewNode) {
		NewNode = _NewNode;
	}

	// Get Create Button Gameobject
	public Button GetButton_Create() {
		return Button_Create;
	}

	// Run Button Setting Function
	public void Button_Setting_Function() {
		Button_Setting.GetComponent<NodeUtilityGroup_Button_Setting> ().Button_Setting_Function ();
	}

	// Run Button Destroy Function
	public void Button_Destroy_Function() {
		Button_Setting.GetComponent<NodeUtilityGroup_Button_Destroy> ().Button_Destory_Function ();
	}

	// Update Relative Position by Index Vector
	public void UpdatePositionByIndex(Vector2 _Index) {
		RelativePosition = NewNodeUtility.NodePosition_IndexToLocal (_Index);
		NewNode.GetComponent<NodeRenderer> ().UpdateLocationWithoutMoving (_Index);
		transform.localPosition = RelativePosition;
	}

	// Update Position Information
	public void UpdateInformation(Vector3 _RelativePosition, GameObject _NewNode) {
		RelativePosition = _RelativePosition;
		transform.localPosition = RelativePosition;
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