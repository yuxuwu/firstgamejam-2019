using System;
using System.Collections.Generic;
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

    public IDNodeBase GetStartNode()
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

    public IDNodeBase GetNodeByID(int id)
    {
        IDNodeBase temp;
        foreach (Node node in nodes)
        {
            if (node is IDNodeBase){
                temp = node as IDNodeBase;
                if (temp.id == id)
                {
                    return temp;
                }
            }
        }

        return null;
    }

    public IDictionary<string, bool> GetSwitches()
    {
        IDictionary<string, bool> switches = new Dictionary<string, bool>();
        SwitchNode temp;
        foreach (Node node in nodes)
        {
            if (node is SwitchNode)
            {
                temp = node as SwitchNode;
                // Check if string is in dict
                if (!switches.ContainsKey(temp.SwitchName))
                {
                    switches.Add(new KeyValuePair<string, bool>(temp.SwitchName, false));
                }
            }
        }
        return switches;
    }
}