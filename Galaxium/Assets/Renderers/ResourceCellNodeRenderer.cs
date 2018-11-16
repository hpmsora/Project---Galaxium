using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellNodeRenderer : MonoBehaviour {

	// Resource Cell Renderer GameObjects
	public Toggle Toggle_Active;
	public Text Text_Name;
	public InputField InputField_Value;

	// Initialization
	void Start () {
	}
	
	// Update Each Frame
	void Update () {
	}

	public void ShowResource(ResourceInfo _ResourceInfo, double _value) {
		Toggle_Active.isOn = _ResourceInfo.IsActive;
		Text_Name.text = _ResourceInfo.Name;
		InputField_Value.text = _value.ToString();
	}
}
