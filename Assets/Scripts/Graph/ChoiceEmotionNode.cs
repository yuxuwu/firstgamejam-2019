using UnityEngine;
using XNode;

public class ChoiceEmotionNode : IDNodeBase {

	[Input(backingValue = ShowBackingValue.Never)] [SerializeField] Node Prev;
	public int Jealousy;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node JealousyRoute;
	public int Pride;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node PrideRoute;
	public int Ambition;
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node AmbitionRoute;

	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node FailRoute;

	public Node GetPrevNode()
	{
		NodePort port = null;
		port = GetOutputPort("Prev");
		return port.Connection.node;
	}

	public Node GetNextNodeJealousy()
	{
		NodePort port = null;
		port = GetOutputPort("JealousyRoute");
		return port.Connection.node;
	}

	public Node GetNextNodePride()
	{
		NodePort port = null;
		port = GetOutputPort("PrideRoute");
		return port.Connection.node;
	}

	public Node GetNextNodeAmbition()
	{
		NodePort port = null;
		port = GetOutputPort("AmbitionRoute");
		return port.Connection.node;
	}

	public Node GetNextFail()
	{
		NodePort port = null;
		port = GetOutputPort("FailRoute");
		return port.Connection.node;
	}

	public override object GetValue(NodePort port)
	{
		return null;
	}
}
