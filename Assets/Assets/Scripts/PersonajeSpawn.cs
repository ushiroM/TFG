using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeSpawn : MonoBehaviour {

    public GameObject hombre;
    public GameObject mujer;
    public GameObject hola;
    private bool spawn;
    private int random;
    private Transform posicion;
    private ConstruccionMovimiento construccionMovimiento;

    void Start()
    {
        spawn = true;
        posicion = gameObject.transform.GetChild(0);
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>();
    }
	// Use this for initialization
	void Update () {
		if(construccionMovimiento.colocado == true && spawn == true)
        {
            spawn = false;
            for (int i = 0; i < 4; i++)
            {
                random = Random.Range(1, 4);
                if (random == 1)
                    Instantiate(hombre, posicion.position, Quaternion.identity);
                else if(random == 2)
                    Instantiate(mujer, posicion.position, Quaternion.identity);
                else
                    Instantiate(hola, posicion.position, Quaternion.identity);
            }
        }

	}
}
