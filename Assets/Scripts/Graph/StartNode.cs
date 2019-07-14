using UnityEngine;
using XNode;

[NodeTint("#f14f41")]
public class StartNode : IDNodeBase
{ 
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	// TODO: Implement this if needed
	bool ValidateIDs()
	{
		return true;
	}

	public override object GetValue(NodePort port) { return null; }
}
