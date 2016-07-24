using UnityEngine;
using System.Collections;

public class PathNodeBuilder : MonoBehaviour {

    public GameObject node;

    void Awake()
    {
        this.GenerateNodes();
    }

    void GenerateNodes()
    {
        float width = transform.localScale.x * 10; // Multiply by 10 because it is a plane
        float height = transform.localScale.z * 10;

        float startPosX = width / 2 * -1 + 0.5f;
        float startPosZ = height / 2 * -1 + 0.5f;

        float endPosX = width / 2 + 0.5f;
        float endPosZ = height / 2 + 0.5f;

        for (float x = startPosX; x < endPosX; x++)
        {
            for (float z = startPosZ; z < endPosZ; z++)
            {
                GameObject.Instantiate(node, new Vector3(x, 0, z), transform.rotation);
            }
        }
    }
}
