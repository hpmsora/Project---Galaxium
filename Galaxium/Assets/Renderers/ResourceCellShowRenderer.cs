using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellShowRenderer : MonoBehaviour {

	// Resource Cell Show Renderer GameObjects
	public Text Text_Name;
	public Text Text_Value;

	// Resource Cell Show Renderer Information
	private GameController NewGameController;

	// Initialization
	void Start () {
		NewGameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update Each Frame
	void Update () {
	}
}
