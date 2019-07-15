using UnityEngine;
using XNode;

[CreateNodeMenu("Misc. Nodes/End Node")]
[NodeTint("#f36f63")]
public class EndNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
}