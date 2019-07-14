using UnityEngine;
using XNode;

[NodeTint("#dad668")]
public class EventNode : IDNodeBase
{
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public string EventType;

	public override object GetValue(NodePort port) { return null; }
}