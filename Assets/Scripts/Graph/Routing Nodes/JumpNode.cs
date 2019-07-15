using UnityEngine;
using XNode;

[CreateNodeMenu("")]
[NodeTint("#e3f09b")]
public class JumpNode : IDNodeBase {

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public int TargetID;

	public override object GetValue(NodePort port) { return null; }
}