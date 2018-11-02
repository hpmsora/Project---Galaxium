using System.Collections.Generic;

public class ResourceInfo {
	
	// Constructor
	public ResourceInfo(string _Name, double _ActualValue) {
		Name = _Name;
		ActualValue = _ActualValue;
	}

	// Name (string)
	public string Name { get; set; }

	// Actual Value (float)
	public double ActualValue { get; set; }

	// Expected Value (float)
	public double ExpectedValue { get; set; }
}
