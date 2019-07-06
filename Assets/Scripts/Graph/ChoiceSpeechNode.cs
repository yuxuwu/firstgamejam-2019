using UnityEngine;
using XNode;

[NodeTint("#5cae8a")]
public class ChoiceSpeechNode : IDNodeBase
{
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	public string SpeakerName;
	[Output(backingValue = ShowBackingValue.Never, dynamicPortList = true)] [SerializeField] [TextArea]
		string[] Choices;
	
	public Node GetPrevNode()
	{
		NodePort port = null;
		port = GetOutputPort("Prev");
		return port.Connection.node;
	}

	public Node GetNextNode(int index)
	{
		NodePort port = null;
		port = GetOutputPort("Choices " + index);
		return port.Connection.node;
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}

}