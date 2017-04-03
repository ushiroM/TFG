using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float speed = 1;
    public bool startMoving;
    Vector3 direction;

	void Update()
    {
        if (startMoving)
        {
            target.position += direction;
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                float h = 7 * Input.GetAxis("Mouse X");
                transform.Rotate(0, h, 0);
            }
        }
    }
    public void StartMovingForward(bool opposite)
    {
        startMoving = true;

        direction = (!opposite) ? target.forward : -target.forward;
        direction *= speed;
    }
    public void StartMovingSides(bool opposite)
    {
        startMoving = true;

        direction = (!opposite) ? target.right : -target.right;
        direction *= speed;
    }
    public void StopMoving()
    {
        startMoving = false;
    }
}
