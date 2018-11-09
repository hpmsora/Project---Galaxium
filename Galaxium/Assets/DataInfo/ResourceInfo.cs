using System.Collections.Generic;

public class ResourceInfo {
	
	// Constructor
	public ResourceInfo(string _Name, double _ActualValue, bool _IsActive = false, double _ExpectedValue = 0.0) {
		IsActive = _IsActive;
		Name = _Name;
		ActualValue = _ActualValue;
		ExpectedValue = _ExpectedValue;
	}

	// Activation (bool)
	public bool IsActive { get; set; }

	// Name (string)
	public string Name { get; set; }

	// Actual Value (float)
	public double ActualValue { get; set; }

	// Expected Value (float)
	public double ExpectedValue { get; set; }
}