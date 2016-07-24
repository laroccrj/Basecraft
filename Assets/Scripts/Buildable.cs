using UnityEngine;
using System.Collections;

public class Buildable : MonoBehaviour {

    public static Hashtable buildables;

    void Awake()
    {
        if (Buildable.buildables == null)
        {
            Buildable.buildables = new Hashtable();
        }

        Buildable.buildables[this.GetInstanceID()] = this;
    }

    public static void snapToGrid(Buildable obj)
    {
        obj.transform.position = new Vector3(
            Mathf.RoundToInt(obj.transform.position.x),
            0,
            Mathf.RoundToInt(obj.transform.position.z)
        );
    }
	
}
