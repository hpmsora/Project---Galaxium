using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUtilityGroup_Button_Setting : MonoBehaviour {

	// Main GameObjects
	public GameObject GameObject_NewNodeSettingWindow;

	// NodeUtilityGrou_Button_Setting Information
	private Vector3 OriginalPosition;
	private GameObject NewNodeSettingWindow;
	private GameObject NodeUtilityGroup;

	// Initialization
	void Start () {
		
	}

	public void Button_Setting_Function(GameObject _NodeUtilityGroup) {
		Debug.Log ("Setting Button Clicked");
		NodeUtilityGroup = _NodeUtilityGroup;
		OriginalPosition = NodeUtilityGroup.transform.position;

		NewNodeSettingWindow = Instantiate(GameObject_NewNodeSettingWindow, OriginalPosition, Quaternion.identity, GameObject.Find ("NodeGroup").transform) as GameObject;
		NewNodeSettingWindow.name = NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetNewNode ().GetComponent<NodeRenderer> ().GetNodeName () + " Setting";
		NewNodeSettingWindow.GetComponent<NodeSettingWindowRenderer> ().UpdateGameUtilityGroup (_NodeUtilityGroup);
	}
}
