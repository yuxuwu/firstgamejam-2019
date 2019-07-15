using UnityEngine;
using XNode;

[CreateNodeMenu("Action Nodes/Music Change Node")]
[NodeTint("#f4b46b")]
public class MusicChangeNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public AudioClip Music;
}