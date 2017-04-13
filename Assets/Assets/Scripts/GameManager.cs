using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject viviendas;
    public GameObject entretenimiento;
    public GameObject templos;
    public GameObject defensas;
    private bool mostrarCasas;
    private bool mostrarJuegos;
    private bool mostrarDioses;
    private bool mostrarMurallas;
    private bool ocultarCasas;
    private bool ocultarJuegos;
    private bool ocultarDioses;
    private bool ocultarMurallas;
    private float Yinicialc;
    private float Yiniciale;
    private float Yinicialt;
    private float Yiniciald;
    public GameObject[] edificios;
    private ConstruccionMovimiento construccionMovimiento;

    void Start()
    {
        mostrarCasas = false;
        mostrarJuegos = false;
        mostrarDioses = false;
        mostrarMurallas = false;
        ocultarCasas = false;
        ocultarJuegos = false;
        ocultarDioses = false;
        ocultarMurallas = false;
    construccionMovimiento = GameObject.FindGameObjectWithTag("Camara").GetComponentInChildren<ConstruccionMovimiento>();
    }
    void Update()
    {
        if (mostrarCasas)
            mostrandoViviendas();
        else if (mostrarJuegos)
            mostrandoEntretenimiento();
        else if (mostrarDioses)
            mostrandoTemplos();
        else if (mostrarMurallas)
            mostrandoDefensas();
        else if (ocultarCasas)
            ocultandoViviendas();
    }
    public void mostrarViviendas()
    {
        if (!viviendas.activeSelf)
        {
            entretenimiento.SetActive(false);
            templos.SetActive(false);
            defensas.SetActive(false);
            viviendas.SetActive(true);
            Yinicialc = viviendas.transform.position.y;
            mostrarCasas = true;
        }
        else
            ocultarCasas = true;
    }
    private void mostrandoViviendas()
    {
        if (viviendas.transform.position.y < Yinicialc + 105)
            viviendas.transform.position = new Vector2(viviendas.transform.position.x, viviendas.transform.position.y + 5);
        else
            mostrarCasas = false;
    }
    private void ocultandoViviendas()
    {
        if (viviendas.transform.position.y > Yinicialc)
            viviendas.transform.position = new Vector2(viviendas.transform.position.x, viviendas.transform.position.y - 5);
        else
        {
            ocultarCasas = false;
            viviendas.SetActive(false);
        }
    }
    public void mostrarEntretenimiento()
    {
        templos.SetActive(false);
        defensas.SetActive(false);
        viviendas.SetActive(false);
        entretenimiento.SetActive(true);
        Yiniciale = entretenimiento.transform.position.y;
        mostrarJuegos = true;
    }
    private void mostrandoEntretenimiento()
    {
        if (entretenimiento.transform.position.y < Yiniciale + 105)
            entretenimiento.transform.position = new Vector2(entretenimiento.transform.position.x, entretenimiento.transform.position.y + 5);
        else
            mostrarJuegos = false;
    }
    public void mostrarTemplos()
    {
        entretenimiento.SetActive(false);
        viviendas.SetActive(false);
        defensas.SetActive(false);
        templos.SetActive(true);
        Yinicialt = templos.transform.position.y;
        mostrarDioses = true;
    }
    private void mostrandoTemplos()
    {
        if (templos.transform.position.y < Yinicialt + 105)
            templos.transform.position = new Vector2(templos.transform.position.x, templos.transform.position.y + 5);
        else
            mostrarDioses = false;
    }
    public void mostrarDefensas()
    {
        viviendas.SetActive(false);
        entretenimiento.SetActive(false);
        templos.SetActive(false);
        defensas.SetActive(true);
        Yiniciald = defensas.transform.position.y;
        mostrarMurallas = true;
    }
    private void mostrandoDefensas()
    {
        if (defensas.transform.position.y < Yiniciald + 105)
            defensas.transform.position = new Vector2(defensas.transform.position.x, defensas.transform.position.y + 5);
        else
            mostrarMurallas = false;
    }
    public void spawnDomus()
    {
        for (int i = 0; i < edificios.Length; i++)
        {
            construccionMovimiento.SetItem(edificios[i]);
        }
    }
}
