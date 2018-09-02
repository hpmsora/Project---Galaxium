using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUtilityRenderer : MonoBehaviour {

	// Main Objects
	public GameObject MainGameController;
	public Button Button_Move;
	public Button Button_Create;

	// Rendering Information
	private Vector3 RelativeLocation = new Vector3(0, 0, 0);

	// Initialize Node
	void Start () {
		Button_Move.onClick.AddListener (Button_Move_Function);
	}
	
	// Update Node
	void Update () {
	}
		

	// Update Position Information
	public void UpdateInformation(Vector3 _RelativeLocation) {
		RelativeLocation = _RelativeLocation;
		transform.localPosition = RelativeLocation;
	}

	// Button Move Function
	void Button_Move_Function() {
	}
}
