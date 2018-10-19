using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnectionRenderer : MonoBehaviour {

    // Node Connection Information
    private Color Color_LineColor;
    private GameObject GameObject_ParentNode;
    private GameObject GameObject_ChildNode;
    private LineRenderer NewLineRenderer;

	// Initialization
    void Start() {
        NewLineRenderer = transform.GetComponent<LineRenderer>();
		NewLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		NewLineRenderer.widthMultiplier = GameConstants.NodeConnection_Width;
    }

	// Update is called once per frame
	void Update () {
        NewLineRenderer.SetPosition(0, GameObject_ParentNode.transform.position);
        NewLineRenderer.SetPosition(1, GameObject_ChildNode.transform.position);
        NewLineRenderer.SetColors(Color_LineColor, Color_LineColor);
    }

    // Set parent and child node
    public void SetParentAndChild(GameObject _ParentNode, GameObject _ChildNode) {
        GameObject_ParentNode = _ParentNode;
        GameObject_ChildNode = _ChildNode;
    }

    // Set color of connection line
    public void SetColor(Color _Color) {
        Color_LineColor = _Color;
    }
}