using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	static GameController instance;

	public Text Text_TestedScore;
	public Text Text_ExpectedScore;

	private ProfileInfo Profile;
	private List<NodeInfo> NodeList;

	// Initialization
	void Start () {
		InitializeProfile ();
		Update ();
	}

	// Initializing Profile
	void InitializeProfile() {
		Profile = new ProfileInfo ();
		Profile.Name = "Player";
		Profile.TestedScore = 0;
		Profile.ExpectedScore = 0;
	}

	// Updating by frame
	void Update () {
		Text_TestedScore.text = Profile.TestedScore.ToString ();
		Text_ExpectedScore.text = Profile.ExpectedScore.ToString ();
	}
}
