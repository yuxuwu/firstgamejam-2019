using UnityEngine;
using XNode;

[CreateNodeMenu("Routing Nodes/Simple 3 Choice Node")]
public class Simple3ChoiceNode : SimpleChoiceNode 
{
	[Output(backingValue = ShowBackingValue.Never)] [SerializeField] Node Next2;
	[TextArea] public string Choice2Text;
}