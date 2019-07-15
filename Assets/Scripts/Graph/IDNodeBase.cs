using UnityEngine;
using XNode;

[CreateNodeMenu("")]
public class IDNodeBase : Node
{
    [SerializeField] public int id;

    public virtual IDNodeBase GetPrevNode()
    {
        NodePort port = null;
        port = GetOutputPort("Prev");
        return port.Connection.node as IDNodeBase;
    }

    public virtual IDNodeBase GetNextNode()
    {
        NodePort port = null;
        port = GetOutputPort("Next");
        return port.Connection.node as IDNodeBase;
    }
}
