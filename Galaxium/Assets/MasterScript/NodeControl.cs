using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeControl : MonoBehaviour {

	public Text Text_Name;
	public Text Text_Cost;

	private string NodeName = "Name";
	private float NodeCost = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text_Name.text = NodeName;
		Text_Cost.text = NodeCost.ToString ();
	}
}
