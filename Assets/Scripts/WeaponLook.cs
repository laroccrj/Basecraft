using UnityEngine;
using System.Collections;

public class WeaponLook : MonoBehaviour {

	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = transform.position.y;
        transform.LookAt(mousePos);
	}
}
