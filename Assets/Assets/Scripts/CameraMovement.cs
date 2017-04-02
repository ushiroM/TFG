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
    }
    public void StartMovingForward(bool opposite)
    {
      //  Debug.Log("ehf");
        startMoving = true;

        //direction = (!opposite) ? target.forward : -target.forward;
        direction *= speed;
    }
    public void StartMovingSides(bool opposite)
    {
       // Debug.Log("ehr");
        startMoving = true;

        direction = (!opposite) ? target.right : -target.right;
        direction *= speed;
    }
    public void StopMoving()
    {
       // Debug.Log("sooo");
        startMoving = false;
    }
}
