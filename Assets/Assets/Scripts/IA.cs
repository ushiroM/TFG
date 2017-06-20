using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

    
    private NavMeshAgent nav;
    private ConstruccionMovimiento construccionMovimiento;
    private GameObject casa;

	void Start () {
        nav = GetComponent<NavMeshAgent>();
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>(); 
	}
	
	// Update is called once per frame
	void Update () {
        if(construccionMovimiento.colocados.Count != 0)
        {
            foreach (var edificio in construccionMovimiento.colocados)
            {
                if(edificio.name == "Foro(Clone)")
                {
                    nav.destination = edificio.transform.position;
                }
            }
        }
		
	}
}
