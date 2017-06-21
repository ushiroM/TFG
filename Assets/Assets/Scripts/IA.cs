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
    private int rand;

	void Start () {
        encontrado = false;
        nav = GetComponent<NavMeshAgent>();
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>(); 
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Waypoint") && !encontrado)
        {
            actual = other.gameObject;
            nav.destination = other.gameObject.transform.position;
            encontrado = true;
        }
    }
	
	void Update () {
        if(construccionMovimiento.colocados.Count != 0 && !encontrado)
        {
            foreach (var edificio in construccionMovimiento.colocados)
            {
                if(edificio.name == "Foro(Clone)")
                {
                    nav.destination = edificio.transform.GetChild(0).position;
                }
            }
        }
        else if (encontrado)
        {
            if (nav.remainingDistance < 3)
            {

                rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                actual = actual.GetComponent<WaypointManager>().hijos[rand];
            }

        }
		
	}
}
