using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    private GameObject pergamino;
    private GameObject texto;

    void Start()
    {

        pergamino = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(5).gameObject;

        switch (transform.parent.parent.name)
        {
            case "Villa(Clone)":
                texto = pergamino.transform.GetChild(1).gameObject;
                break;
            case "Domus(Clone)":
                texto = pergamino.transform.GetChild(3).gameObject;
                break;
            case "Insulae(Clone)":
                texto = pergamino.transform.GetChild(2).gameObject;
                break;
            case "Anfiteatro(Clone)":
                texto = pergamino.transform.GetChild(5).gameObject;
                break;
            case "Teatro(Clone)":
                texto = pergamino.transform.GetChild(6).gameObject;
                break;
            case "Circo(Clone)":
                texto = pergamino.transform.GetChild(7).gameObject;
                break;
            case "Acueducto(Clone)":
                texto = pergamino.transform.GetChild(4).gameObject;
                break;
            case "Puerta(Clone)":
                texto = pergamino.transform.GetChild(8).gameObject;
                break;
            case "Foro(Clone)":
                texto = pergamino.transform.GetChild(0).gameObject;
                break;
            case "Arco(Clone)":
                texto = pergamino.transform.GetChild(9).gameObject;
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Camara" && Input.GetKeyDown(KeyCode.E))
        {
            pergamino.SetActive(true);
            texto.SetActive(true);
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Camara")
        {
            pergamino.SetActive(false);
            texto.SetActive(false);
        }
    }
}
