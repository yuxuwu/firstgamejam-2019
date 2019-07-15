using UnityEngine;
using XNode;

[CreateNodeMenu("Start End Nodes/End Node")]
[NodeTint("#f36f63")]
public class EndNode : IDNodeBase 
{
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
}