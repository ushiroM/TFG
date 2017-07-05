using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private GameObject edificio;
    [HideInInspector]public bool colocado;
    private EdificioColocable edificioColocable;
    private EdificioArrastrable edificioArrastrable;
    private GameManager gameManager;
    private IAmanager iaManager;
    private bool arrastrando;
    private bool dobleClick;
    private bool destruyendo;
    private bool rotado;
    private GameObject edificioPadre;
    [HideInInspector]public List<GameObject> arrastrables;
    private TexturasTerreno terreno;
    Vector3 tamaño;
    Vector3 posicion;
    Vector2 tiles;

    void Start()
    {
        dobleClick = false;
        arrastrando = false;
        destruyendo = false;
        rotado = false;
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        iaManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<IAmanager>();
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
                    if (edificio.name == "Acueducto(Clone)" || edificio.name == "Muralla(Clone)")
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
                        prepararPintar();
                        if(edificio.name == "Anfiteatro(Clone)" || edificio.name == "Circo(Clone)" || edificio.name == "Teatro(Clone)" || edificio.name == "Foro(Clone)" || edificio.name == "Arco(Clone)")
                            iaManager.edificiosPublicos.Add(edificio);
                        if (edificio.name == "Anfiteatro(Clone)")
                            posicion = new Vector3(edificio.transform.position.x, edificio.transform.position.y, edificio.transform.position.z + edificio.GetComponent<Collider>().bounds.size.z / 2);
                        else if (edificio.name == "Circo(Clone)")
                        {
                            if(!rotado)
                                posicion = new Vector3(edificio.transform.position.x, edificio.transform.position.y, edificio.transform.position.z - edificio.GetComponent<Collider>().bounds.size.z / 3);
                            else
                                posicion = new Vector3(edificio.transform.position.x + edificio.GetComponent<Collider>().bounds.size.x / 3, edificio.transform.position.y, edificio.transform.position.z);
                        }
                        else if (edificio.name == "Teatro(Clone)")
                            posicion = new Vector3(edificio.transform.position.x, edificio.transform.position.y, edificio.transform.position.z + edificio.GetComponent<Collider>().bounds.size.z / 3f);
                        else
                            posicion = new Vector3(edificio.transform.position.x, edificio.transform.position.y, edificio.transform.position.z);
                        terreno.Pintar(tamaño, posicion, tiles, edificio);
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
               if (!rotado)
                   rotado = true;
               else
                   rotado = false;
               edificio.transform.rotation = Quaternion.Lerp(edificio.transform.rotation, edificio.transform.rotation * Quaternion.AngleAxis(90, Vector3.up), 200 * 2f * Time.deltaTime);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (!rotado)
                    rotado = true;
                else
                    rotado = false;
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

    private void prepararPintar()
    {
        switch (edificio.name)
        {
            case "Domus(Clone)":
                if (!rotado)
                {
                    tiles = new Vector2(5, 5);
                    tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.2f);
                }
                else
                {
                    tiles = new Vector2(5, 5);
                    tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.2f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                }
                break;
            case "Anfiteatro(Clone)":
                tiles = new Vector2(19, 27);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Foro(Clone)":
                tiles = new Vector2(19, 27);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Arco(Clone)":
                tiles = new Vector2(5, 5);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Circo(Clone)":
                tiles = new Vector2(35, 18);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Teatro(Clone)":
                tiles = new Vector2(11, 12);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Insulae(Clone)":
                tiles = new Vector2(4, 4);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;
            case "Villa(Clone)":
                tiles = new Vector2(7, 12);
                tamaño = new Vector3(edificio.GetComponent<Collider>().bounds.size.x * 0.15f, edificio.GetComponent<Collider>().bounds.size.y, edificio.GetComponent<Collider>().bounds.size.z * 0.15f);
                break;

        }
    }

    private void ArrastrarEdificio()
    {
        Transform Ant;
        float xSize = edificio.GetComponent<Collider>().bounds.size.x;

        RaycastHit hit;
        Vector3 rayDirection = edificio.transform.GetChild(2).position + edificio.transform.up;
        Physics.Raycast(edificio.transform.position + edificio.transform.up, rayDirection.normalized, out hit);

        if ((edificio.name == "Acueducto(Clone)" || edificio.name == "AcueductoTrozo(Clone)") && !destruyendo)
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

        else if ((edificio.name == "Muralla(Clone)" || edificio.name == "MurallaTrozo(Clone)") && !destruyendo)
        {
            Ant = edificioPadre.transform;
            if (edificio.GetComponent<EdificioArrastrable>().salido == true)
            {
                edificio = Instantiate(gameManager.MurallaTrozo);
                edificio.transform.parent = edificioPadre.transform;
                edificio.transform.rotation = edificioPadre.transform.rotation;
                arrastrables.Add(edificio);
                edificio.transform.position = new Vector3(rayDirection.x, Ant.position.y - 0.35f, rayDirection.z);
                edificio.transform.localScale = new Vector3(1, 1, 1);

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
                if(edificio.name == "Acueducto(Clone)" || edificio.name == "AcueductoTrozo(Clone)")
                {
                    Ant = edificio.transform;
                    edificio = Instantiate(gameManager.acueducto);
                    edificio.transform.parent = edificioPadre.transform;
                    edificio.transform.rotation = edificioPadre.transform.rotation;
                    arrastrables.Add(edificio);
                    edificio.transform.position = new Vector3(rayDirection.x, Ant.position.y, rayDirection.z);

                }
                /*else if (edificio.name == "Muralla(Clone)" || edificio.name == "MurallaTrozo(Clone)")
                {

                }*/
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
