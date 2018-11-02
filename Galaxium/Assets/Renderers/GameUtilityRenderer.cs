using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUtilityRenderer : MonoBehaviour {
	
	//Game Utility GameObjects
	public Text Text_TestedScore;
	public Text Text_ExpectedScore;
	public GameObject GameObject_ResourceBoard;
	public GameObject  ScoreBorad;
	
	//Game Utility Renderer Information
	private float TestedScore;
	private float ExpectedScore;

	// Use this for initialization
	void Start () {
		TestedScore = 0;
		ExpectedScore = 0;
    }

	void Update() {
		Text_TestedScore.text = TestedScore.ToString ();
		Text_ExpectedScore.text = ExpectedScore.ToString ();
	}

	// Update Expected and Tested Score
	public void UpdateScores(float _TestedScore, float _ExpectedScore) {
		TestedScore = _TestedScore;
		ExpectedScore = _ExpectedScore;
	}
}
