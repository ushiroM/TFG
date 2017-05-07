using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;
    public float speed = 1;
    public bool startMoving;
    Vector3 direction;
    private Vector3 posicionAerea;
    private bool cambiar;
    private CamaraPrimeraPersona pp;
    private ConstruccionMovimiento construccionMovimiento;
    private Collider collider;
    private GameObject canvas;
    private Transform límites;
   

    void Start()
    {
        cambiar = false;
        pp = GetComponent<CamaraPrimeraPersona>();
        construccionMovimiento = GetComponentInChildren<ConstruccionMovimiento>();
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        límites = GameObject.FindGameObjectWithTag("Límites").transform;
    }

    void Update()
    {
        if (cambiar)
        {
           cambiarPrimeraPersona();
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
        /*if (target.position.x < límites.GetChild(2).position.x && target.position.x > límites.GetChild(3).position.x && target.position.z < límites.GetChild(0).position.z && target.position.z > límites.GetChild(1).position.z)
        {*/
        direction = (!opposite) ? target.forward : -target.forward;
        direction *= speed;
        startMoving = true;
        // }

        /*if (!opposite) {
            startMoving = true;
            direction = target.forward;
            direction *= speed;
        }
        else
        {
            startMoving = true;
            direction = -target.forward;
            direction *= speed;
        }*/

    }
    public void StartMovingSides(bool opposite)
    {
        startMoving = true;
        direction = (!opposite) ? target.right : -target.right;
        direction *= speed;
        /*if (!opposite)
        {
            startMoving = true;
            direction = target.right;
            direction *= speed;
        }
        else
        {
            startMoving = true;
            direction = -target.right;
            direction *= speed;
        }*/
    }
    public void StopMoving()
    {
        startMoving = false;
    }
    public void cambiarPrimeraPersona()
    {
        if (transform.position.y > 0)
        {
            if (transform.position.y < 80)
                if (transform.GetChild(0).rotation.x > 0)
                    transform.GetChild(0).Rotate(transform.GetChild(0).rotation.x - 5, transform.GetChild(0).rotation.y, transform.GetChild(0).rotation.z);

            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        }
        else
        {
            transform.GetChild(0).rotation = Quaternion.identity;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            cambiar = false;
            pp.enabled = true;
            collider.enabled = true;
            construccionMovimiento.enabled = false;
            canvas.SetActive(false);
            enabled = false;
        }
      
    }
}
