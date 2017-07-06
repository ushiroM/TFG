using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MurallaSpawn : MonoBehaviour {

    public GameObject guardia;
    private Transform posicion;
    private GameObject instanciado;

    void Start()
    {
        posicion = gameObject.transform.GetChild(0);
      
    }

    public void apostarGuardias()
    {
       instanciado = Instantiate(guardia, posicion.position, Quaternion.identity);
        instanciado.GetComponent<NavMeshAgent>().enabled = false;
    }
}
