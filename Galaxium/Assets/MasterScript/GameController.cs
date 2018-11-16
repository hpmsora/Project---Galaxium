using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	static GameController instance;

	// Mainscene GameObjects
	public Button Button_ResourceSetting;
	public Button Button_ChangeModeTemp;
	public GameObject GameObject_GameUtility;
	public GameObject GameObject_NodeGroup;

	// Prefab GameObjects
	public GameObject GameObject_Node;
	public GameObject GameObject_NodeUtilityGroup;
	public GameObject GameObject_NodeConnection;
	public GameObject GameObject_NodeSettingWindow;

	// Additional Objects
	public Material Material_NodeConnection;

	// GameController Information
	private string GameMode = GameConstants.Mode_Game;
	private ProfileInfo Profile;
	private Transform Transform_NodeGroup;
	private List<GameObject> List_GameObject_Node;
	private NodeController NewNodeController;

	// Temporary Fixed Game Information
	private GameObject NewNode;
	private GameObject NewNodeUtility;

	// Initialization
	void Start () {
		InitializeProfile ();
		InitializeState ();

		//-------Test-------
		TestInit ();
	}

	// Initializing Profile
	void InitializeProfile() {
		Profile = new ProfileInfo ("New Player", GameConstants.Resource_Number);
		for (int i = 0; i < GameConstants.Resource_Number; i++) {
			Profile.ResourceList[i] = new ResourceInfo("New Resource " + (i + 1).ToString(), 0.0, i);
		}
	}

	// Initializing State
	void InitializeState() {
		NewNodeController = gameObject.GetComponent<NodeController> ();
	}

	// Test Initialization
	void TestInit() {
        Debug.Log("Test Initiation");
		GameObject TestNode_1 = NewNodeController.CreateNewNode(GameObject_Node, "Test 0 0", 12.3, new Vector2(0, 0));
		GameObject TestNode_2 = NewNodeController.CreateNewNode(GameObject_Node, "Test 1 0", 12.3, new Vector2(1, 0));
		TestNode_1.GetComponent<NodeRenderer>().AddNodeChild(TestNode_2);
		GameObject TestNode_3 = NewNodeController.CreateNewNode(GameObject_Node, "Test 0 1", 12.3, new Vector2(0, 1));
		TestNode_1.GetComponent<NodeRenderer>().AddNodeChild(TestNode_3);

		Button_ChangeModeTemp.onClick.AddListener (ChangeModeButton);
		Button_ResourceSetting.onClick.AddListener (ResourceSettingButton);
	}

	// Testing
	void TestPrint() {
		Debug.Log("Child List Start");
		GameObject Test = GameObject.Find("Test 0 0");
		PrintAllChildren(Test);
		Debug.Log("Child List Finish");
	}

	void PrintAllChildren(GameObject _Node) {
		Debug.Log(_Node.name);
		if (_Node.GetComponent<NodeRenderer>().GetNodeChildrenList().Count != 0) {
			foreach(GameObject EachNode in _Node.GetComponent<NodeRenderer>().GetNodeChildrenList()) {
				PrintAllChildren(EachNode);
				NewNodeController.CreateNodeConnection(_Node, EachNode, GameObject_NodeConnection, Color.red);
			}
		}
	}

	// Updating by frame
	void Update () {
		GameObject_GameUtility.GetComponent<GameUtilityRenderer>().UpdateScores(Profile.TestedScore, Profile.ExpectedScore);
	}

	// Get Profile Resource Info
	public ResourceInfo[] GetProfileResources() {
		return Profile.ResourceList;
	}

	// Set Profile Resource Info except expected value
	public void SetProfileResources(ResourceInfo[] _ResourceInfo) {
		if (Profile.ResourceList.Length == _ResourceInfo.Length) {
			for (int i = 0; i < Profile.ResourceList.Length; i ++) {
				Profile.ResourceList[i].IsActive = _ResourceInfo[i].IsActive;
				Profile.ResourceList[i].Name = _ResourceInfo[i].Name;
				Profile.ResourceList[i].ActualValue = _ResourceInfo[i].ActualValue;
			}
		}
	}

	// Changing game mode
	void ChangeModeButton() {
		Debug.Log ("Mode Changing");
		Debug.Log ("Previous Mode: " + GameMode);

		if (GameMode == GameConstants.Mode_Game) {
			GameMode = GameConstants.Mode_Sandbox;
			Debug.Log ("Showing All Node Utilities");
			NewNodeController.ShowingNodeUtilityGroup (GameObject_NodeUtilityGroup, GameObject_NodeGroup);
		} else if (GameMode == GameConstants.Mode_Sandbox) {
			GameMode = GameConstants.Mode_Game;
			Debug.Log ("Destroying All Node Utilities");
			NewNodeController.DestoryNodeUtilityGroup (GameObject_NodeGroup);
		} else {
			Debug.Log ("Invalid Game Mode, Initializing Game Mode Now");
			GameMode = GameConstants.Mode_Game;
			NewNodeController.DestoryNodeUtilityGroup (GameObject_NodeGroup);
		}

		TestPrint();

		Debug.Log ("Current Mode: " + GameMode);
	}

	// Resource setting window
	void ResourceSettingButton() {
		GameObject Setting = Instantiate(GameObject_NodeSettingWindow, new Vector3 (0, 0, 0), Quaternion.identity, GameObject.Find("GameUtility").transform);
		Setting.transform.localPosition = new Vector3(0, 0, 0);
		Setting.GetComponent<ResourceSettingWindowRenderer>().ShowResourceList(Profile.ResourceList);
	}
}
