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
    [HideInInspector]public List<GameObject> arrastrables;

    void Start()
    {
        dobleClick = false;
        arrastrando = false;
        destruyendo = false;
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
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
                    if(edificio.name == "Acueducto(Clone)")
                    {
                        arrastrables.Add(edificio);
                        arrastrando = true;
                        colocado = true;
                        ArrastrarEdificio();
                    }
                    else
                        colocado = true;
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
        float xAnt;
        float yAnt;
        float zAnt;
        float xSize = edificio.GetComponent<Collider>().bounds.size.x;
        if(edificio.name == "Acueducto(Clone)" || edificio.name == "AcueductoTrozo(Clone)" && !destruyendo)
        {
            xAnt = edificio.transform.position.x;
            yAnt = edificio.transform.position.y;
            zAnt = edificio.transform.position.z;
         
            if(edificio.GetComponent<EdificioArrastrable>().salido == true){
                edificio = Instantiate(gameManager.AcueductoTrozo);
                arrastrables.Add(edificio);
                edificio.transform.position = new Vector3(xAnt - xSize/2, yAnt, zAnt);
                
            }
        }
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
