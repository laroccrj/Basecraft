using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour {

    public static Dictionary<Vector2, PathNode> pathNodes;

    public PathNode left;
    public PathNode right;
    public PathNode forward;
    public PathNode backward;

    private Vector2 coord{get; set;}

    void Awake()
    {
        if (PathNode.pathNodes == null)
        {
            PathNode.pathNodes = new Dictionary<Vector2, PathNode>();
        }

        Vector2 coord = new Vector2(transform.position.x, transform.position.z);
        this.coord = coord;
        PathNode.pathNodes.Add(coord, this);

        Vector2 leftChord = new Vector2(coord.x - 1, coord.y);
        Vector2 rightChord = new Vector2(coord.x + 1, coord.y);
        Vector2 forwardChord = new Vector2(coord.x, coord.y + 1);
        Vector2 backwardChord = new Vector2(coord.x, coord.y - 1);

        if (PathNode.pathNodes.ContainsKey(leftChord))
        {
            this.left = PathNode.pathNodes[leftChord];
            this.left.right = this;
        }
        if (PathNode.pathNodes.ContainsKey(rightChord))
        {
            this.right = PathNode.pathNodes[rightChord];
            this.right.left = this;
        }
        if (PathNode.pathNodes.ContainsKey(forwardChord))
        {
            this.forward = PathNode.pathNodes[forwardChord];
            this.forward.backward = this;
        }
        if (PathNode.pathNodes.ContainsKey(backwardChord))
        {
            this.backward = PathNode.pathNodes[backwardChord];
            this.backward.forward = this;
        }
    }
}