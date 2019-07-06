using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeTint("#dad668")]
public class EventNode : IDNodeBase
{
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public string EventType;

	public Node GetPrevNode()
	{
		NodePort port = null;
		port = GetOutputPort("Prev");
		return port.Connection.node;
	}

	public Node GetNextNode()
	{
		NodePort port = null;
		port = GetOutputPort("Next");
		return port.Connection.node;
	}

	public override object GetValue(NodePort port) { return null; }
}