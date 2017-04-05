using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float speed = 1;
    public bool startMoving;
    Vector3 direction;
    private Vector3 posicionAerea;
    private bool cambiar = false;
    private CamaraPrimeraPersona pp;

    void Awake()
    {
        pp = GetComponent<CamaraPrimeraPersona>();
    }

    void Update()
    {
        if (cambiar)
        {
            posicionAerea = transform.position;
            if (transform.position.y > 0)
            {
                if (transform.position.y < 80)
                    if (transform.GetChild(0).rotation.x > 0)
                        transform.GetChild(0).Rotate(transform.GetChild(0).rotation.x - 5, transform.GetChild(0).rotation.y, transform.GetChild(0).rotation.z);

                transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
            }
            else
            {
                transform.GetChild(0).Rotate(0, transform.GetChild(0).rotation.y, transform.GetChild(0).rotation.z);
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);
                cambiar = false;
                pp.enabled = true;
                enabled = false;
            }
        }
        else if (startMoving)
        {
            target.position += direction;
        }
        else
        {
            if (Input.GetMouseButton(1) && !cambiar)
            {
                float h = 7 * Input.GetAxis("Mouse X");
                transform.Rotate(0, h, 0);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                cambiar = true;
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
