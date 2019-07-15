﻿using UnityEngine;
using XNode;

[CreateNodeMenu("Misc. Nodes/Start Node")]
[NodeTint("#f14f41")]
public class StartNode : IDNodeBase
{ 
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next;

	public override object GetValue(NodePort port) { return null; }
}
