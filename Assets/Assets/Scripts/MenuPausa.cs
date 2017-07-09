using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour {

    private GameObject pausa;
    private bool pulsado;

    void Start()
    {
        pulsado = false;
        pausa = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(7).gameObject;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!pulsado)
            {
                pulsado = true;
                pausa.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                pulsado = false;
                pausa.SetActive(false);
                Time.timeScale = 1;
            }

        }
	}

    public void Cerrar()
    {
        pulsado = false;
        pausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
