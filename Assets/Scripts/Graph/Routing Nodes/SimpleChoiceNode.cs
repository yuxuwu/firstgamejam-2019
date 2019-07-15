using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Simple Choice Node")]
[NodeTint("#5cae8a")]
public class SimpleChoiceNode : IDNodeBase
{
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	public string SpeakerName;
	[TextArea] public string Text;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next0;
	[TextArea] public string Choice0Text;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next1;
	[TextArea] public string Choice1Text;

	public IDNodeBase GetNextNode(int index)
	{
		NodePort port = null;
		port = GetOutputPort("ChoiceText" + index);
		return port.Connection.node as IDNodeBase;
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}

}