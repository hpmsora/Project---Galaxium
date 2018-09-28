﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	static GameController instance;

	// Mainscene GameObjects
	public Text Text_TestedScore;
	public Text Text_ExpectedScore;
	public Button Button_ChangeModeTemp;
	public GameObject GameObject_NodeGroup;

	// Prefab GameObjects
	public GameObject GameObject_Node;
	public GameObject GameObject_NodeUtilityGroup;

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
		Profile = new ProfileInfo ();
		Profile.Name = "Player";
		Profile.TestedScore = 0;
		Profile.ExpectedScore = 0;
	}

	// Initializing State
	void InitializeState() {
		NewNodeController = gameObject.GetComponent<NodeController> ();

	}

	// Test Initialization
	void TestInit() {
        Debug.Log("Test Initiation");
		CreateNewNode("Test", 12.3, new Vector2(1, 1));
		CreateNewNode("Test", 12.3, new Vector2(1, 2));
		CreateNewNode("Test", 12.3, new Vector2(1, 3));
		CreateNewNode("Test", 12.3, new Vector2(2, 1));
		Button_ChangeModeTemp.onClick.AddListener (ChangeModeButton);
        Debug.Log(Button_ChangeModeTemp.name);
	}

	// Updating by frame
	void Update () {
		Text_TestedScore.text = Profile.TestedScore.ToString ();
		Text_ExpectedScore.text = Profile.ExpectedScore.ToString ();
	}

	// Create New Node
	GameObject CreateNewNode(string _NodeName, double _Cost, Vector3 _RelativeLocation) {
		NewNode = Instantiate (GameObject_Node, new Vector3 (0, 0, 0), Quaternion.identity, GameObject_NodeGroup.transform) as GameObject;
		NewNode.GetComponent<NodeRenderer> ().UpdateInformation (_NodeName, _Cost, _RelativeLocation);
		NewNode.name = _NodeName;

		return NewNode;
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

		Debug.Log ("Current Mode: " + GameMode);
	}
}
