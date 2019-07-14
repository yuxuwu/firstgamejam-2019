using UnityEngine;
using XNode;

[NodeTint("#5e897c")]
public class SpeechNode : IDNodeBase
{

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public string SpeakerName;
	[TextArea] public string Text;

	public override object GetValue(NodePort port) { return null; }
}