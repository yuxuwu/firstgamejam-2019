using UnityEngine;
using XNode;

[NodeTint("#f14f41")]
public class StartNode : Node
{ 
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public Node GetNextNode()
	{
		NodePort port = null;
		port = GetOutputPort("Next");
		return port.Connection.node;
	}

	// TODO: Implement this if needed
	bool ValidateIDs()
	{
		return true;
	}

	public override object GetValue(NodePort port) { return null; }
}
