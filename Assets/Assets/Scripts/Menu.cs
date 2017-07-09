using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public void cargarNueva()
    {
        SceneManager.LoadScene("escena1");
    }

    public void cargarCiudad()
    {
        SceneManager.LoadScene("Ciudad");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
