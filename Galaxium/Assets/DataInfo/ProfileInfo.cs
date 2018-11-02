using System.Collections.Generic;

public class ProfileInfo {
	// Name (string)
	public string Name { get; set; }

	// Tested score (float) 
	public float TestedScore { get; set; }

	// Expected score
	// tested score + not-tested score
	public float ExpectedScore { get; set; }

	// Resource list
	// all resource information contains
	public List<ResourceInfo> ResourceList{ get; set; }

	// Node list (list of NodeInfo)
	// all node information contains
	public List<NodeInfo> NodeList { get; set; }
}
