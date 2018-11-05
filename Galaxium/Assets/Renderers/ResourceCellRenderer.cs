using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellRenderer : MonoBehaviour {

	// Resource Cell Renderer GameObjects
	public Toggle Toggle_Active;
	public InputField InputField_Name;
	public InputField InputField_Value;
	public Button Button_Remove;

	// Initialization
	void Start () {
		Button_Remove.onClick.AddListener(RemoveButton);
	}
	
	// Update Each Frame
	void Update () {
	}

	// Run Remove Button
	void RemoveButton() {
		Destroy(gameObject);
	}
}
