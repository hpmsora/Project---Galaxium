using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnectionRenderer : MonoBehaviour {

    public Material LineMat;

    public GameObject GameObject_ParentNode;
    public GameObject GameObject_ChildNode;
	
	// Update is called once per frame
	void Update () {
		
	}

    void DrawNodeConnection() {
        Vector3 Parent_Position = GameObject_ParentNode.transform.position;
        Vector3 Child_Position = GameObject_ChildNode.transform.position;

        GL.Begin(GL.LINES);

        LineMat.SetPass(0);

        GL.Color(new Color(LineMat.color.g, LineMat.color.g, LineMat.color.b, LineMat.color.a));
        GL.Vertex(Parent_Position);
        GL.Vertex(Child_Position);
        GL.End();
    }

    void OnRenderObject()
    {
        DrawNodeConnection();
    }

    void OnDrawGizmos()
    {
        DrawNodeConnection();
    }
}
