using UnityEngine;
using XNode;

public class ToBrotherSceneNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;
}