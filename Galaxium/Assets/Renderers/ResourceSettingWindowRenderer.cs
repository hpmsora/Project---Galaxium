using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSettingWindowRenderer : MonoBehaviour {

	// ResourceSettingWindowRenderer Gameobjects
	public Text Text_Title;
	public Button Button_Close;
	public Button Button_Apply;
	public Button Button_Confirm;
	public GameObject GameObject_ResourcesList;

	// Prefab GameObjects
	public GameObject GameObject_ResourceCell;

	// ResourceSettingWindowRenderer Information
	private GameObject[] NewResourceCells;
	

	// Use this for initialization
	void Start () {
		Text_Title.text = "Resource Setting";
		Button button_Close = Button_Close.GetComponent<Button> ();
		Button button_Apply = Button_Apply.GetComponent<Button> ();
		Button button_Confirm = Button_Confirm.GetComponent<Button> ();

		button_Close.onClick.AddListener (Button_Close_Function);
		button_Apply.onClick.AddListener (Button_Apply_Function);
		button_Confirm.onClick.AddListener (Button_Confirm_Function);
	}

	// Update is called once per frame
	void Update () {
	}

	// Initiating Resource List
	public void ShowResourceList(ResourceInfo[] _ResourceInfoList) {
		RemoveAllResourceListGameObject();
		NewResourceCells = new GameObject[_ResourceInfoList.Length];
		for (int i = 0; i < _ResourceInfoList.Length; i++) {
			NewResourceCells[i] = Instantiate(GameObject_ResourceCell, new Vector3(0 ,0, 0), Quaternion.identity, GameObject_ResourcesList.transform);
			NewResourceCells[i].transform.localPosition = new Vector3(0, 0, 0);
			NewResourceCells[i].GetComponent<ResourceCellRenderer>().ShowResource(_ResourceInfoList[i]);
		}
	}

	// Remove All Resource List
	void RemoveAllResourceListGameObject() {
		foreach (Transform EachResources in GameObject_ResourcesList.transform) {
			GameObject.Destroy(EachResources.transform);
		}
	}

	// Run Button Cancel Function
	void Button_Close_Function() {
		Destroy (gameObject);
	}
	
	// Run Button Apply Function
	void Button_Apply_Function() {
		GameController NewGameController = GameObject.Find("GameController").GetComponent<GameController>();
		ResourceInfo[] NewResourceInfoList = new ResourceInfo[NewResourceCells.Length];
		
		for (int i = 0; i < NewResourceCells.Length; i++) {
			ResourceCellRenderer NewResourceCellRenderer =  NewResourceCells[i].GetComponent<ResourceCellRenderer>();
			NewResourceInfoList[i] = new ResourceInfo(_IsActive:NewResourceCellRenderer.GetIsActive(), _Name: NewResourceCellRenderer.GetName(), _ActualValue: NewResourceCellRenderer.GetValue());
		}

		NewGameController.SetProfileResources(NewResourceInfoList);
	}

	// Run Button Confirm Function 
	void Button_Confirm_Function() {
		Button_Apply_Function();
		Destroy (gameObject);
	}
}
