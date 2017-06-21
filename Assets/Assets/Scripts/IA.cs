using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

    
    private NavMeshAgent nav;
    private ConstruccionMovimiento construccionMovimiento;
    private GameObject casa;
    private bool encontrado;
    private GameObject actual;
    private IAmanager iaManager;
    private bool nuevoEdificio;
    private int rand;
    private int vueltas;
    private int contador;

	void Start () {
        contador = 0;
        nuevoEdificio = true;
        encontrado = false;
        nav = GetComponent<NavMeshAgent>();
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>();
        iaManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<IAmanager>();
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Waypoint") && !encontrado)
        {
            if (other.transform.parent.name == casa.name)
            {
                actual = other.gameObject;
                nav.destination = other.gameObject.transform.position;
                encontrado = true;
            }
        }
    }
	
	void Update () {
        Debug.Log(nav.destination);
        if (nuevoEdificio)
        {
            rand = Random.Range(0, iaManager.edificiosPublicos.Count -1);
            Debug.Log(rand);
            Debug.Log(iaManager.edificiosPublicos[rand].name);
            casa = iaManager.edificiosPublicos[rand];
            nuevoEdificio = false;
        }

        switch (casa.name)
        {
            case "Foro(Clone)":
                if(!encontrado)
                {
                    nav.destination = casa.transform.position;
                     
                }
                else 
                {
                    if (nav.remainingDistance < 3)
                    {
                        rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                        nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                        actual = actual.GetComponent<WaypointManager>().hijos[rand];
                    }

                }
                break;
            case "Anfiteatro(Clone)":
                Debug.Log(casa.name);
                if (contador == 0 || contador == vueltas)
                {
                    vueltas = Random.Range(0, 4);
                    contador = 0;
                }
                   

                if (!encontrado)
                {
                    Debug.Log("voy para el coliseo");
                    nav.destination = casa.transform.position;
                    Debug.Log(nav.destination);

                }
                else
                {
                    if (nav.remainingDistance < 3)
                    {
                        if(contador == vueltas)
                            StartCoroutine("espera");

                        rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                        nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                        actual = actual.GetComponent<WaypointManager>().hijos[rand];
                        contador++;
                    }

                }
                break;
            case "Circo(Clone)":
                break;
            case "Arco(Clone)":
                break;
            case "Teatro(Clone)":
                break;
        }
    }

    IEnumerator espera()
    {
        nav.Stop();
        transform.LookAt(casa.transform);
        yield return new WaitForSeconds(3f);
        nav.Resume();

    }
}
