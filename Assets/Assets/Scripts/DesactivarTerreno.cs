using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarTerreno : MonoBehaviour {
    private GameObject terrain;


    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Terrain");
    }


    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Camara")
        {
            terrain.GetComponent<Terrain>().enabled = false;
            transform.parent.GetChild(transform.parent.childCount - 1).gameObject.SetActive(false);
            if(transform.parent.name.Contains("Domus"))
                transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(true);
        }

    }

    public void OnTriggerExit(Collider c)
    {
        if (c.tag == "Camara")
        {
            terrain.GetComponent<Terrain>().enabled = true;
            transform.parent.GetChild(transform.parent.childCount - 1).gameObject.SetActive(true);
            if (transform.parent.name.Contains("Domus"))
                transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(false);
        }
    }
}
