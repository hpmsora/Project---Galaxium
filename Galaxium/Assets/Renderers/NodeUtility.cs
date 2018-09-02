using UnityEngine;

public class NodeUtility {

	// Node Position Index to Local Position
	public Vector3 NodePosition_IndexToLocal(Vector2 _Index) {
		return new Vector3 (_Index.x * GameConstants.Node_Interim, _Index.y * GameConstants.Node_Interim, 0);
	}
}
