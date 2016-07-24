using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1;

	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            this.Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.Move(Vector3.right);
        }
	}

    void Move(Vector3 direction)
    {
        if(!Physics.Raycast(transform.position, direction, 0.5f)) {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
