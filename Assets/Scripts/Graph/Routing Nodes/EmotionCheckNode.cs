using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Emotion Check Node")]
[NodeTint("#52414c")]
public class EmotionCheckNode : IDNodeBase {

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node JealousyRoute;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node PrideRoute;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node AmbitionRoute;

	public IDNodeBase GetNextNodeJealousy()
	{
		NodePort port = null;
		port = GetOutputPort("JealousyRoute");
		return port.Connection.node as IDNodeBase;
	}

	public IDNodeBase GetNextNodePride()
	{
		NodePort port = null;
		port = GetOutputPort("PrideRoute");
		return port.Connection.node as IDNodeBase;
	}

	public IDNodeBase GetNextNodeAmbition()
	{
		NodePort port = null;
		port = GetOutputPort("AmbitionRoute");
		return port.Connection.node as IDNodeBase;
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}
}
