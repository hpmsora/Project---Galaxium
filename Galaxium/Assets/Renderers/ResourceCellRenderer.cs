using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellRenderer : MonoBehaviour {

	// Resource Cell Renderer GameObjects
	public Toggle Toggle_Active;
	public InputField InputField_Name;
	public InputField InputField_Value;

	// Initialization
	void Start () {
	}
	
	// Update Each Frame
	void Update () {
	}

	// Get Toggle Value
	public bool GetIsActive() {
		return Toggle_Active.isOn;
	}

	// Get Name Value
	public string GetName() {
		return InputField_Name.text;
	}

	// Get Value
	public double GetValue() {
		return double.Parse(InputField_Value.text);
	}

	// Show Resource Information
	public void ShowResource(ResourceInfo _ResourceInfo) {
		Toggle_Active.isOn = _ResourceInfo.IsActive;
		InputField_Name.text = _ResourceInfo.Name;
		InputField_Value.text = _ResourceInfo.ActualValue.ToString();
	}
}
