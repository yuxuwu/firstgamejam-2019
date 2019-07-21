using UnityEngine;
using XNode;

public class ActivateTeaNode : IDNodeBase {
	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;
}