using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

    public Buildable template;

	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.template.transform.position = mousePos;
        Buildable.snapToGrid(this.template);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(template);
        }
	}
}
