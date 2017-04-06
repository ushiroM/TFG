using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPrimeraPersona : MonoBehaviour {
    public int speed = 10;
    [HideInInspector]public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    [HideInInspector]public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    private bool cambiar;
    private CameraMovement cameraMovement;
    private ConstruccionMovimiento construccionMovimiento;
    private ConstruccionManager construccionManager;
    private Collider collider;
    // Use this for initialization
    void Start () {
        cambiar = false;
        cameraMovement = GetComponent<CameraMovement>();
        construccionMovimiento = GetComponentInChildren<ConstruccionMovimiento>();
        construccionManager = GetComponentInChildren<ConstruccionManager>();
        collider = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!cambiar)
        {
            movimiento();
            rotacion();
            if (Input.GetKeyDown(KeyCode.V))
            {
                cambiar = true;
               
            }
        }
        else
        {
            cambiarVistaAerea();
        }
        

    }
    void movimiento()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        right.y = 0;
        forward.y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += -right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += right * speed * Time.deltaTime;
        }
    }
    void rotacion()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

    }
    public void cambiarVistaAerea()
    {
        if (transform.position.y < 200)
        {
            if (transform.GetChild(0).rotation.x < 60f)
            {
                transform.GetChild(0).Rotate(transform.GetChild(0).rotation.x + 10f, 0, 0);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
        else
        {
            //transform.GetChild(0).Rotate(60f, 0, 0);
            transform.position = new Vector3(transform.position.x, 200, transform.position.z);
            cambiar = false;
            collider.enabled = false;
            cameraMovement.enabled = true;
            construccionMovimiento.enabled = true;
            construccionManager.enabled = true;
            enabled = false;
        }
    }
}
