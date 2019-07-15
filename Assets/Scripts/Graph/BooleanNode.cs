using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Switch Node")]
[NodeTint("#ffd25a")]
public class SwitchNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	
	public bool Switch;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node TrueNext;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node FalseNext;

}