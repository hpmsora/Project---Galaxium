using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeRenderer : MonoBehaviour {

	// Main Objects
	public Text Text_Name;
	public Text Text_Cost;

	// Rendering Information
	private string NodeName = "Name";
	private double NodeCost = 0;
	private Vector3 RelativeLocation = new Vector3(0, 0, 0);

	// Initialize Node
	void Start () {

	}

	// Update Node
	void Update () {
		Text_Name.text = NodeName;
		Text_Cost.text = NodeCost.ToString ();
	}

	// Update Information
	public void UpdateInformation(string _NodeName, double _NodeCost, Vector3 _RelativeLocation) {
		NodeName = _NodeName;
		NodeCost = _NodeCost;
		UpdateLocation (_RelativeLocation);
	}

	// Update Location Only
	public void UpdateLocation(Vector3 _RelativeLocation) {
		RelativeLocation = _RelativeLocation;
		transform.localPosition = RelativeLocation;
	}
}
