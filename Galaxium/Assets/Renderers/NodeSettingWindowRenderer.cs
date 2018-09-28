using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeSettingWindowRenderer : MonoBehaviour {

	// Main GameObjects
	public InputField InputField_NodeName;
	public InputField InputField_NodeLaborCost;
	public Button Button_Close;
	public Button Button_Apply;
	public Button Button_Confirm;

	// NodeSettingWindow Information
	private GameObject Node;
	private GameObject NodeUtilityGroup;

	// Use this for initialization
	void Start () {
		Button button_Close = Button_Close.GetComponent<Button> ();
		Button button_Apply = Button_Apply.GetComponent<Button> ();
		Button button_Confirm = Button_Confirm.GetComponent<Button> ();

		button_Close.onClick.AddListener (Button_Close_Function);
		button_Apply.onClick.AddListener (Button_Apply_Function);
		button_Confirm.onClick.AddListener (Button_Confirm_Function);
	}

	public void UpdateGameUtilityGroup(GameObject _NodeUtilityGroup) {
		NodeUtilityGroup = _NodeUtilityGroup;
		Node = NodeUtilityGroup.GetComponent<NodeUtilityGroupRenderer> ().GetNewNode ();

		InputField_NodeName.text = Node.GetComponent<NodeRenderer> ().GetNodeName ();
		InputField_NodeLaborCost.text = Node.GetComponent<NodeRenderer> ().GetNodeLaborCost ().ToString ();
	}

	// Run Button Cancel Function
	void Button_Close_Function() {
		Destroy (gameObject);
	}

	// Run Button Apply Function
	void Button_Apply_Function() {
		Node.GetComponent<NodeRenderer> ().SetNodeName(InputField_NodeName.text);
		Node.GetComponent<NodeRenderer> ().SetNodeLaborCost(double.Parse (InputField_NodeLaborCost.text));
	}

	// Run Button Confirm Function 
	void Button_Confirm_Function() {
		Node.GetComponent<NodeRenderer> ().SetNodeName(InputField_NodeName.text);
		Node.GetComponent<NodeRenderer> ().SetNodeLaborCost(double.Parse (InputField_NodeLaborCost.text));
		Destroy (gameObject);
	}
}