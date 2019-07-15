using UnityEngine;
using XNode;

[CreateNodeMenu("Action Nodes/Add Choice Node")]
[NodeTint("#f6c185")]
public class AddChoiceNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;
	public int TargetID;	
	[TextArea] public string ChoiceText;
}