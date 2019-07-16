using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Switch Node")]
[NodeTint("#ffd25a")]
public class SwitchNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	
	public string SwitchName;

	[Output(backingValue = ShowBackingValue.Never)] public IDNodeBase TrueNext;
	[Output(backingValue = ShowBackingValue.Never)] public IDNodeBase FalseNext;

	public IDNodeBase GetFalseNext()
	{
		NodePort port = null;
		port = GetOutputPort("FalseNext");
		return port.Connection.node as IDNodeBase;
	}

	public IDNodeBase GetTrueNext()
	{
		NodePort port = null;
		port = GetOutputPort("TrueNext");
		return port.Connection.node as IDNodeBase;
	}
}