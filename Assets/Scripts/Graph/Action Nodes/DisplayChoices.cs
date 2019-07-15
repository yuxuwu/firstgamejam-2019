using UnityEngine;
using XNode;

[CreateNodeMenu("Action Nodes/Display Choices Node")]
[NodeTint("#f5ba78")]
public class DisplayChoices : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;
}