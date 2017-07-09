using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DesactivarTerreno : MonoBehaviour {
    private GameObject terrain;
    private GameObject suelo;


    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Terrain");
        if (SceneManager.GetActiveScene().name == "Ciudad")
            suelo = GameObject.FindGameObjectWithTag("Suelo");
    }


    public void OnTriggerEnter(Collider c)
    {
        if(SceneManager.GetActiveScene().name == "escena1")
        {
            if (c.tag == "Camara")
            {
                terrain.GetComponent<Terrain>().enabled = false;
                transform.parent.GetChild(transform.parent.childCount - 1).gameObject.SetActive(false);
                if (transform.parent.name.Contains("Domus"))
                    transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(true);
            }
        }
        else
        {
            if (c.tag == "Camara")
            {
                terrain.GetComponent<Terrain>().enabled = false;
                suelo.SetActive(false);
                if (transform.parent.name.Contains("Domus"))
                    transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(true);
            }
        }
       

    }

    public void OnTriggerExit(Collider c)
    {
        if (SceneManager.GetActiveScene().name == "escena1")
        {
            if (c.tag == "Camara")
            {
                terrain.GetComponent<Terrain>().enabled = true;
                transform.parent.GetChild(transform.parent.childCount - 1).gameObject.SetActive(true);
                if (transform.parent.name.Contains("Domus"))
                    transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(false);
            }
        }
        else
        {
            if (c.tag == "Camara")
            {
                terrain.GetComponent<Terrain>().enabled = true;
                suelo.SetActive(true);
                if (transform.parent.name.Contains("Domus"))
                    transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);
            }
        }
    }
}
