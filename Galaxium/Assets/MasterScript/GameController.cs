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
	public GameObject GameObject_NodeGroup;

	// Prefab Objects
	public GameObject GameObject_Node;

	// Main Game Information
	private string GameMode = Constants.Mode_Game;
	private ProfileInfo Profile;
	private Transform Transform_NodeGroup;
	private List<GameObject> List_GameObject_Node;

	// Temporary Fixed Game Information
	private GameObject NewNode;

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
		//NodeInfo Node_01 = new NodeInfo ("Node 1", 11.1);
		CreateNewNode("Test", 12.3, new Vector3(0, 100, 100));
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

	void ChangeModeButton() {
		
	}
}
