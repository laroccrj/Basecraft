using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour {

    public static Dictionary<NodeCoordinate, PathNode> pathNodes;

    public PathNode left;
    public PathNode right;
    public PathNode forward;
    public PathNode backward;

    private NodeCoordinate coord{get; set;}

    void Awake()
    {
        if (PathNode.pathNodes == null)
        {
            PathNode.pathNodes = new Dictionary<NodeCoordinate, PathNode>(new NodeCoordinateComparer());
        }

        NodeCoordinate coord = new NodeCoordinate(transform.position.x, transform.position.z);
        this.coord = coord;
        PathNode.pathNodes.Add(coord, this);

        NodeCoordinate leftChord = new NodeCoordinate(coord.x - 1, coord.z);
        NodeCoordinate rightChord = new NodeCoordinate(coord.x + 1, coord.z);
        NodeCoordinate forwardChord = new NodeCoordinate(coord.x, coord.z + 1);
        NodeCoordinate backwardChord = new NodeCoordinate(coord.x, coord.z - 1);

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

public class NodeCoordinate
{
    public float x;
    public float z;

    public NodeCoordinate(float x, float z)
    {
        this.x = x;
        this.z = z;
    }

    public bool Equals(NodeCoordinate coord)
    {
        return (this.x == coord.x && this.z == coord.z);
    }

    public override int GetHashCode()
    {
        return string.Format("{0}x{1}", this.x, this.z).GetHashCode();
    }

    public override string ToString()
    {
        return "Coordinate: " + this.x + " x " + this.z;
    }
}

public class NodeCoordinateComparer : IEqualityComparer<NodeCoordinate>
{
    public bool Equals(NodeCoordinate a, NodeCoordinate b)
    {
        return (a.x == b.x && a.z == b.z);
    }

    public int GetHashCode(NodeCoordinate coord)
    {
        return string.Format("{0}x{1}", coord.x, coord.z).GetHashCode();
    }


}