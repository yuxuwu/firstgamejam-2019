using System;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class ScenarioGraph : NodeGraph { 

    int largestID = 0;


    void _SetLargestID()
    {
        largestID = 0;
        IDNodeBase tempNode;
        foreach (Node node in nodes)
        {
            if (node is IDNodeBase)
            {
                tempNode = (IDNodeBase) node;
                if (tempNode.id > largestID)
                {
                    largestID = tempNode.id;
                }
            }
        }
    }

    public override Node AddNode(Type type)
    {
        _SetLargestID();
        Node node = base.AddNode(type);
        if (node is IDNodeBase)
        {
            IDNodeBase tempNode = (IDNodeBase) node;
            tempNode.id = largestID + 1;
            return tempNode;
        }
        return node;
    }

    public override Node CopyNode(Node original)
    {
        _SetLargestID();
        Node node = base.CopyNode(original);
        if (node is IDNodeBase)
        {
            IDNodeBase tempNode = (IDNodeBase) node;
            tempNode.id = largestID + 1;
            return tempNode;
        }
        return node;
    }

    public Node GetStartNode()
    {
        foreach (Node node in nodes)
        {
            if (node is StartNode)
            {
                Debug.Log("Start node set");
                return (StartNode) node;
            }
        }
        Debug.Log("No Start Node found!!!");
        return null;
    }
}