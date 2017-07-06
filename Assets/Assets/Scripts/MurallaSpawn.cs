using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MurallaSpawn : MonoBehaviour {

    public GameObject guardia;
    private Transform posicion;
    private GameObject instanciado;

    public void apostarGuardias()
    {
        posicion = gameObject.transform.GetChild(0);
        instanciado = Instantiate(guardia, posicion.position, Quaternion.identity);
        instanciado.GetComponent<NavMeshAgent>().enabled = false;
    }

    public void guardiasPuerta()
    {
        for (int i = 0; i < 4; i++)
        {
            instanciado = Instantiate(guardia, transform.GetChild(i).position, Quaternion.identity);
            instanciado.GetComponent<NavMeshAgent>().enabled = false;
        }
        
    }

}
