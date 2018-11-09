using System.Collections.Generic;

public class ProfileInfo {
	// Constructor
	public ProfileInfo(string _Name, int _Resource_Number) {
		Name = _Name;
		TestedScore = 0;
		ExpectedScore = 0;
		ResourceList = new ResourceInfo[_Resource_Number];
		NodeList = new List<NodeInfo>();
	}
	// Name (string)
	public string Name { get; set; }

	// Tested score (float) 
	public float TestedScore { get; set; }

	// Expected score
	// tested score + not-tested score
	public float ExpectedScore { get; set; }

	// Resource list
	// all resource information contains
	public ResourceInfo[] ResourceList{ get; set; }

	// Node list (list of NodeInfo)
	// all node information contains
	public List<NodeInfo> NodeList { get; set; }
}
