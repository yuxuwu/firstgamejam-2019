using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Emotion Check Node")]
[NodeTint("#52414c")]
public class EmotionCheckNode : IDNodeBase {

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;

	public int Jealousy = -1;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node JealousyRoute;

	public int Pride = -1;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node PrideRoute;

	public int Ambition = -1;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node AmbitionRoute;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node FailRoute;

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

	public override IDNodeBase GetNextNode()
	{
		NodePort port = null;
		port = GetOutputPort("FailRoute");
		return port.Connection.node as IDNodeBase;
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}
}
