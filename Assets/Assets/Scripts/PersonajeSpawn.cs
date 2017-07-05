using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeSpawn : MonoBehaviour {

    public GameObject hombre;
    public GameObject mujer;
    private bool spawn;
    private int random;
    private Transform posicion;
    private ConstruccionMovimiento construccionMovimiento;
    private IAmanager iaManager; 

    void Start()
    {
        spawn = true;
        posicion = gameObject.transform.GetChild(0);
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>();
        iaManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<IAmanager>();
    }
	// Use this for initialization
	void Update () {
		if(construccionMovimiento.colocado == true && spawn == true && iaManager.edificiosPublicos.Count > 0)
        {
            spawn = false;
            for (int i = 0; i < 4; i++)
            {
                random = Random.Range(1, 3);
                if (random == 1)
                    Instantiate(hombre, posicion.position, Quaternion.identity);
                else
                    Instantiate(mujer, posicion.position, Quaternion.identity);
            }
        }

	}
}
