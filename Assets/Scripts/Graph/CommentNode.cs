using UnityEngine;
using XNode;

[CreateNodeMenu("Misc. Nodes/Comment Node")]
[NodeTint("#596157")]
public class CommentNode : Node {
	[TextArea][SerializeField] string Comment;
}