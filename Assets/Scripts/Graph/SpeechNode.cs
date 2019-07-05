using UnityEngine;
using XNode;

[NodeTint("#5e897c")]
public class SpeechNode : Node
{

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public int id;
	public string SpeakerName;
	[TextArea] public string Text;

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