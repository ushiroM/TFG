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
    public GameObject domus;
    public GameObject arco;
    public GameObject coliseo;
    public GameObject acueducto;
    public GameObject circo;
    public GameObject teatro;
    public GameObject foro;
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
        Yinicialc = viviendas.transform.position.y;
        Yiniciale = entretenimiento.transform.position.y;
        Yiniciald = defensas.transform.position.y;
        Yinicialt = templos.transform.position.y;
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
        else if (ocultarJuegos)
            ocultandoEntretenimiento();
        else if (ocultarDioses)
            ocultandoTemplos();
        else if (ocultarMurallas)
            ocultandoDefensas();
    }
    public void mostrarViviendas()
    {
        if (!viviendas.activeSelf)
        {
            if (entretenimiento.activeSelf)
            {
                entretenimiento.SetActive(false);
                entretenimiento.transform.position = new Vector2(entretenimiento.transform.position.x, Yiniciale);
            }
            else if (templos.activeSelf)
            {
                templos.SetActive(false);
                templos.transform.position = new Vector2(templos.transform.position.x, Yinicialt);
            }
            else if (defensas.activeSelf)
            {
                defensas.SetActive(false);
                defensas.transform.position = new Vector2(defensas.transform.position.x, Yiniciald);
            }
            viviendas.SetActive(true);
            mostrarCasas = true;
        }
        else
            ocultarCasas = true;
    }
    private void mostrandoViviendas()
    {
        if (viviendas.transform.position.y < Yinicialc * 2.9)
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
        if (!entretenimiento.activeSelf)
        {
            if (viviendas.activeSelf)
            {
                viviendas.SetActive(false);
                viviendas.transform.position = new Vector2(viviendas.transform.position.x, Yinicialc);
            }
            else if (templos.activeSelf)
            {
                templos.SetActive(false);
                templos.transform.position = new Vector2(templos.transform.position.x, Yinicialt);
            }
            else if (defensas.activeSelf)
            {
                defensas.SetActive(false);
                defensas.transform.position = new Vector2(defensas.transform.position.x, Yiniciald);
            }
            entretenimiento.SetActive(true);
            mostrarJuegos = true;
        }
        else
            ocultarJuegos = true;
      
       
        
    }
    private void mostrandoEntretenimiento()
    {
        if (entretenimiento.transform.position.y < Yiniciale * 2.9)
            entretenimiento.transform.position = new Vector2(entretenimiento.transform.position.x, entretenimiento.transform.position.y + 5);
        else
            mostrarJuegos = false;
    }
    private void ocultandoEntretenimiento()
    {
        if (entretenimiento.transform.position.y > Yiniciale)
            entretenimiento.transform.position = new Vector2(entretenimiento.transform.position.x, entretenimiento.transform.position.y - 5);
        else
        {
            ocultarJuegos = false;
            entretenimiento.SetActive(false);
        }
    }
    public void mostrarTemplos()
    {
        if (!templos.activeSelf)
        {
            if (viviendas.activeSelf)
            {
                viviendas.SetActive(false);
                viviendas.transform.position = new Vector2(viviendas.transform.position.x, Yinicialc);
            }
            else if (entretenimiento.activeSelf)
            {
                entretenimiento.SetActive(false);
                entretenimiento.transform.position = new Vector2(templos.transform.position.x, Yiniciale);
            }
            else if (defensas.activeSelf)
            {
                defensas.SetActive(false);
                defensas.transform.position = new Vector2(defensas.transform.position.x, Yiniciald);
            }
            templos.SetActive(true);
            mostrarDioses = true;
        }
        else
            ocultarDioses = true;
    }
    private void mostrandoTemplos()
    {
        if (templos.transform.position.y < Yinicialt * 2.9)
            templos.transform.position = new Vector2(templos.transform.position.x, templos.transform.position.y + 5);
        else
            mostrarDioses = false;
    }
    private void ocultandoTemplos()
    {
        if (templos.transform.position.y > Yinicialt)
            templos.transform.position = new Vector2(templos.transform.position.x, templos.transform.position.y - 5);
        else
        {
            ocultarDioses = false;
            templos.SetActive(false);
        }
    }
    public void mostrarDefensas()
    {
        if (!defensas.activeSelf)
        {

            if (viviendas.activeSelf)
            {
                viviendas.SetActive(false);
                viviendas.transform.position = new Vector2(viviendas.transform.position.x, Yinicialc);
            }
            else if (entretenimiento.activeSelf)
            {
                entretenimiento.SetActive(false);
                entretenimiento.transform.position = new Vector2(templos.transform.position.x, Yiniciale);
            }
            else if (templos.activeSelf)
            {
                templos.SetActive(false);
                templos.transform.position = new Vector2(templos.transform.position.x, Yinicialt);
            }
            defensas.SetActive(true);
            mostrarMurallas = true;
        }
        else
            ocultarMurallas = true;
    }
    private void mostrandoDefensas()
    {
        if (defensas.transform.position.y < Yiniciald * 2.9)
            defensas.transform.position = new Vector2(defensas.transform.position.x, defensas.transform.position.y + 5);
        else
            mostrarMurallas = false;
    }
    private void ocultandoDefensas()
    {
        if (defensas.transform.position.y > Yiniciald)
            defensas.transform.position = new Vector2(defensas.transform.position.x, defensas.transform.position.y - 5);
        else
        {
            ocultarMurallas = false;
            defensas.SetActive(false);
        }
    }
    public void spawnDomus()
    {
       construccionMovimiento.SetItem(domus);
    }
    public void spawnArco()
    {
       construccionMovimiento.SetItem(arco);
    }
    public void spawnColiseo()
    {
        construccionMovimiento.SetItem(coliseo);
    }
    public void spawnAcueducto()
    {
        construccionMovimiento.SetItem(acueducto);
    }
    public void spawnCirco()
    {
        construccionMovimiento.SetItem(circo);
    }
    public void spawnTeatro()
    {
        construccionMovimiento.SetItem(teatro);
    }
    public void spawnForo()
    {
        construccionMovimiento.SetItem(foro);
    }
}
