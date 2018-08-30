using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUtilityRenderer : MonoBehaviour {

	// Main Objects
	public Button Button_Move;
	public Button Button_Create;

	// Rendering Information
	private Vector3 RelativeLocation = new Vector3(0, 0, 0);

	// Initialize Node
	void Start () {
		
	}
	
	// Update Node
	void Update () {
		transform.localPosition = RelativeLocation;
	}

	// Update Information
	public void UpdateInformation(Vector3 _RelativeLocation) {
		RelativeLocation = _RelativeLocation;
	}
}
