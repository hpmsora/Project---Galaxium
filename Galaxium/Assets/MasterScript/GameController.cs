using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class Constants {
	public const string Mode_Game = "Mode_Game";
	public const string Mode_Sandbox = "Mode_SandBox";
}

public class GameController : MonoBehaviour {

	static GameController instance;

	// Mainscene Objects
	public Text Text_TestedScore;
	public Text Text_ExpectedScore;
	public Button Button_ChangeModeTemp;
	public GameObject GameObject_NodeGroup;

	// Prefab Objects
	public GameObject GameObject_Node;
	public GameObject GameObject_NodeUtility;

	// Main Game Information
	private string GameMode = Constants.Mode_Game;
	private ProfileInfo Profile;
	private Transform Transform_NodeGroup;
	private List<GameObject> List_GameObject_Node;

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
		Profile = new ProfileInfo ();
		Profile.Name = "Player";
		Profile.TestedScore = 0;
		Profile.ExpectedScore = 0;
	}

	// Initializing State
	void InitializeState() {
	}

	// Test Initialization
	void TestInit() {
		CreateNewNode("Test", 12.3, new Vector3(0, 200, 100));
		Button_ChangeModeTemp.onClick.AddListener (ChangeModeButton);
	}

	// Create New Node
	GameObject CreateNewNode(string _NodeName, double _Cost, Vector3 _RelativeLocation) {
		NewNode = Instantiate (GameObject_Node, new Vector3 (0, 0, 0), Quaternion.identity, GameObject_NodeGroup.transform) as GameObject;
		NewNode.GetComponent<NodeRenderer> ().UpdateInformation (_NodeName, _Cost, _RelativeLocation);
		NewNode.name = _NodeName;

		return NewNode;
	}

	// Updating by frame
	void Update () {
		Text_TestedScore.text = Profile.TestedScore.ToString ();
		Text_ExpectedScore.text = Profile.ExpectedScore.ToString ();
	}

	// Changing game mode
	void ChangeModeButton() {
		Debug.Log ("Mode Changing");
		Debug.Log ("Previous Mode: " + GameMode);

		if (GameMode == Constants.Mode_Game) {
			GameMode = Constants.Mode_Sandbox;
			Debug.Log ("Showing All Node Utilities");
			ShowingNodeUtility ();
		} else if (GameMode == Constants.Mode_Sandbox) {
			GameMode = Constants.Mode_Game;
			Debug.Log ("Destroying All Node Utilities");
			DestoryNodeUtility ();
		} else {
			Debug.Log ("Invalid Game Mode, Initializing Game Mode Now");
			GameMode = Constants.Mode_Game;
			DestoryNodeUtility ();
		}

		Debug.Log ("Current Mode: " + GameMode);
	}

	// Create uility tools for each node
	void ShowingNodeUtility() {
		Vector3 NodeUtilityLocation = new Vector3 (0, 0, 0);
		GameObject[] AllNodes = GetAllNodeGameObjects ();

		foreach (GameObject EachAllNode in AllNodes) {
			NewNodeUtility = Instantiate (GameObject_NodeUtility, new Vector3 (0, 0, 0), Quaternion.identity, EachAllNode.transform) as GameObject;
			NewNodeUtility.GetComponent<NodeUtilityRenderer> ().UpdateInformation (NodeUtilityLocation);
			NewNodeUtility.name = EachAllNode.name + "Utility";
		}
	}

	// Destroy uility tools on all nodes
	void DestoryNodeUtility() {
		GameObject[] AllNodeUtilities = GetAllNodeUtilityGameObjects ();

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
