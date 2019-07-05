using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeTint("#5e897c")]
public class SpeechNode : BaseConnectingNode
{
	public int id;

	public string SpeakerName;
	[TextArea] public string Text;
}