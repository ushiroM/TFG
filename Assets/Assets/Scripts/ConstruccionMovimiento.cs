using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private GameObject edificio;
    private bool colocado;
    private EdificioColocable edificioColocable;
    private EdificioArrastrable edificioArrastrable;
    private GameManager gameManager;
    private bool arrastrando;
    private bool dobleClick;
    private bool destruyendo;
    private GameObject edificioPadre;
    [HideInInspector]public List<GameObject> arrastrables;
    private TexturasTerreno terreno;

    void Start()
    {
        dobleClick = false;
        arrastrando = false;
        destruyendo = false;
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        terreno = GameObject.FindGameObjectWithTag("Terrain").GetComponent<TexturasTerreno>();
    }

    // Update is called once per frame
    void Update () {
        if(edificio != null && !colocado && !arrastrando)
        {
            edificioColocable = edificio.GetComponent<EdificioColocable>();
            Vector3 raton = Input.mousePosition;
            raton = new Vector3(raton.x, raton.y, transform.position.y);
            Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(raton);
            edificio.transform.position = new Vector3(p.x,edificio.transform.position.y,p.z);

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    if (edificio.name == "Acueducto(Clone)")
                    {
                        arrastrables.Add(edificio);
                        arrastrando = true;
                        colocado = true;
                        edificioPadre = edificio;

                        ArrastrarEdificio();
                    }
                    else
                    {
                        colocado = true;
                        Vector3 posicion = new Vector3(edificio.transform.position.x, edificio.transform.position.y, edificio.transform.position.z);
                        terreno.Pintar(edificio.GetComponent<Collider>().bounds.size *0.5f, posicion);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(edificio);
                edificio = null;

            }
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
               edificio.transform.rotation = Quaternion.Lerp(edificio.transform.rotation, edificio.transform.rotation * Quaternion.AngleAxis(90, Vector3.up), 200 * 2f * Time.deltaTime);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                edificio.transform.rotation = Quaternion.Lerp(edificio.transform.rotation, edificio.transform.rotation * Quaternion.AngleAxis(-90, Vector3.up), 200 * 2f * Time.deltaTime);
            }

        }
        else  if(arrastrando == true)
        {
            dobleClick = true;
            ArrastrarEdificio();
        }
       
	}

    bool IsLegalPosition()
    {
        if (edificioColocable.colliders.Count > 0)
            return false;
        return true;
    }

    public void SetItem(GameObject b)
    {
        colocado = false;
        edificio = Instantiate(b);
        edificioColocable = edificio.GetComponent<EdificioColocable>();
    }

    private void ArrastrarEdificio()
    {
        Transform Ant;
        float xSize = edificio.GetComponent<Collider>().bounds.size.x;

        RaycastHit hit;
        Vector3 rayDirection = edificio.transform.GetChild(2).position + edificio.transform.up;
        Physics.Raycast(edificio.transform.position + edificio.transform.up, rayDirection.normalized, out hit);

        if (edificio.name == "Acueducto(Clone)" || edificio.name == "AcueductoTrozo(Clone)" && !destruyendo)
        {
            Ant = edificio.transform;
                              
            if (edificio.GetComponent<EdificioArrastrable>().salido == true){
                edificio = Instantiate(gameManager.AcueductoTrozo);
                edificio.transform.parent = edificioPadre.transform;
                edificio.transform.rotation = edificioPadre.transform.rotation;
                arrastrables.Add(edificio);
                edificio.transform.position = new Vector3(rayDirection.x, Ant.position.y, rayDirection.z);

            }
        }
        Vector3 posraton = Input.mousePosition;
        posraton.z = GetComponent<Camera>().transform.position.y - edificioPadre.transform.position.y;
        Vector3 posratonmundo = GetComponent<Camera>().ScreenToWorldPoint(posraton);
        float angulo = -Mathf.Atan2(edificioPadre.transform.position.z - posratonmundo.z, edificioPadre.transform.position.x - posratonmundo.x) * Mathf.Rad2Deg;
        edificioPadre.transform.rotation = Quaternion.Slerp(edificioPadre.transform.rotation, Quaternion.Euler(0, angulo, 0), 8 * Time.deltaTime);

        if (dobleClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                arrastrando = false;
                dobleClick = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                foreach (var trozo in arrastrables)
                {
                    destruyendo = true;
                    Destroy(trozo);
                }
                arrastrables.Clear();
                arrastrando = false;
            }
        }
    }
}
