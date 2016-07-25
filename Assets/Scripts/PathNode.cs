using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour {

    public static Dictionary<Vector2, PathNode> pathNodes;

	public static void findDistances()
	{
		bool change = true;

		while(change)
		{
			change = false;

			foreach(PathNode node in PathNode.pathNodes.Values) {
				if(node.updateDistances())
				{
					change = true;
				}
			}
		}
	}

    public PathNode left;
    public PathNode right;
    public PathNode forward;
    public PathNode backward;

	public Dictionary<Vector2, int> distances;

	public Vector2 coord{get; set;}

    void Awake()
    {
		this.distances = new Dictionary<Vector2,int>();

        if (PathNode.pathNodes == null)
        {
            PathNode.pathNodes = new Dictionary<Vector2, PathNode>();
        }

        Vector2 coord = new Vector2(transform.position.x, transform.position.z);
        this.coord = coord;
        PathNode.pathNodes.Add(coord, this);

        Vector2 leftCoord = new Vector2(coord.x - 1, coord.y);
        Vector2 rightCoord = new Vector2(coord.x + 1, coord.y);
        Vector2 forwardCoord = new Vector2(coord.x, coord.y + 1);
        Vector2 backwardCoord = new Vector2(coord.x, coord.y - 1);

        if (PathNode.pathNodes.ContainsKey(leftCoord))
        {
            this.left = PathNode.pathNodes[leftCoord];
            this.left.right = this;
        }
        if (PathNode.pathNodes.ContainsKey(rightCoord))
        {
            this.right = PathNode.pathNodes[rightCoord];
            this.right.left = this;
        }
        if (PathNode.pathNodes.ContainsKey(forwardCoord))
        {
            this.forward = PathNode.pathNodes[forwardCoord];
            this.forward.backward = this;
        }
        if (PathNode.pathNodes.ContainsKey(backwardCoord))
        {
            this.backward = PathNode.pathNodes[backwardCoord];
            this.backward.forward = this;
        }
    }

	public void initializeDisntances(Dictionary<Vector2, int> distances) {

		distances[this.coord] = 0;

		if(this.right != null)
		{
			distances[this.right.coord] = 1;
		}

		if(this.left != null)
		{
			distances[this.left.coord] = 1;
		}

		if(this.forward != null)
		{
			distances[this.forward.coord] = 1;
		}

		if(this.backward != null)
		{
			distances[this.backward.coord] = 1;
		}

		this.distances = distances;
	}

	public bool updateDistances()
	{
		bool change = false;

		if(this.checkDistanceForNode(this.right)) {
			change = true;
		}

		if(this.checkDistanceForNode(this.left)) {
			change = true;
		}

		if(this.checkDistanceForNode(this.forward)) {
			change = true;
		}

		if(this.checkDistanceForNode(this.backward)) {
			change = true;
		}

		return change;
	}

	private bool checkDistanceForNode(PathNode node)
	{
		bool change = false;
		Debug.Log(node.coord);

		foreach(Vector2 coord in node.distances.Keys)
		{
			int distance = node.distances[coord];
			if(distance != -1 && distance < this.distances[coord])
			{
				this.distances[coord] = distance + this.distances[node.coord];
				change = true;
			}
		}

		return change;
	}
}