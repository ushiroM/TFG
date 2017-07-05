using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour {

    
    private NavMeshAgent nav;
    private ConstruccionMovimiento construccionMovimiento;
    private GameObject casa;
    private bool encontrado;
    private GameObject actual;
    private IAmanager iaManager;
    private bool nuevoEdificio;
    private bool dentro;
    private bool paseando;
    private int rand;
    private int cambioRandom;
    private float tiempo;
    private int casaDest;
    private int vueltas;
    private int contador;
    private Animator anim;

	void Start () {
        contador = 0;
        nuevoEdificio = true;
        encontrado = false;
        nav = GetComponent<NavMeshAgent>();
        construccionMovimiento = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ConstruccionMovimiento>();
        iaManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<IAmanager>();
        anim = GetComponent<Animator>();
        tiempo = Random.Range(60, 121);
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (casa != null)
        {
            if (other.gameObject.name.Contains("Waypoint") && !encontrado)
            {
                if (other.transform.parent.name == casa.name)
                {
                    actual = other.gameObject;
                    nav.destination = other.gameObject.transform.position;
                    encontrado = true;
                }
            }
        }
    }
	
	void Update () {
        if (iaManager.edificiosPublicos.Count > 0)
        {
           if(tiempo <= 0)
               nuevoEdificio = true;

           if (paseando)
            {
                tiempo -= Time.deltaTime;
            }
               

            if (nuevoEdificio)
            {
                anim.SetBool("Andando", true);
                tiempo = Random.Range(60, 121);
                casaDest = Random.Range(0, iaManager.edificiosPublicos.Count);
                casa = iaManager.edificiosPublicos[casaDest];
                nuevoEdificio = false;
                paseando = false;
                dentro = false;
                encontrado = false;
            }

            switch (casa.name)
            {
                case "Foro(Clone)":
                    if (!encontrado)
                    {
                        dentro = false;
                        nav.destination = casa.transform.position;
                    }
                    else if(encontrado && !dentro)
                    {
                        if (nav.remainingDistance < 3)
                        {
                            paseando = true;
                            if(actual.name.Contains("Waypoint (6)"))
                            {
                                dentro = true;
                                rand = Random.Range(0, 10);
                                nav.destination = casa.transform.GetChild(rand).position;
                                actual = casa.transform.GetChild(rand).gameObject;
                            }
                            else if(actual.GetComponent<WaypointManager>().hijos.Length > 0){
                                rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                                nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                                actual = actual.GetComponent<WaypointManager>().hijos[rand];
                            }                          
                        }

                    }
                    else if (dentro)
                    {
                        if (contador == 0 || contador == vueltas)
                        {
                            vueltas = Random.Range(0, 4);
                            contador = 0;
                        }
                        
                        if (nav.remainingDistance < 3)
                        {
                            contador++;
                            if (contador == vueltas)
                                StartCoroutine("espera");

                            rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                            nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                            actual = actual.GetComponent<WaypointManager>().hijos[rand];
                        }
                    }
                    break;

                case "Anfiteatro(Clone)":
                    if (contador == 0 || contador == vueltas)
                    {
                        vueltas = Random.Range(0, 4);
                        contador = 0;
                    }


                    if (!encontrado)
                    {
                        nav.destination = casa.transform.GetChild(0).position;
                    }
                    else
                    {
                        if (nav.remainingDistance < 3)
                        {
                            paseando = true;
                            contador++;
                            if (contador == vueltas)
                                StartCoroutine("espera");

                            rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                            nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                            actual = actual.GetComponent<WaypointManager>().hijos[rand];
                        }

                    }
                    break;

                case "Circo(Clone)":
                    if (contador == 0 || contador == vueltas)
                    {
                        vueltas = Random.Range(0, 4);
                        contador = 0;
                    }


                    if (!encontrado)
                    {
                        nav.destination = casa.transform.GetChild(0).position;
                    }
                    else
                    {
                        if (nav.remainingDistance < 3)
                        {
                            paseando = true;
                            contador++;
                            if (contador == vueltas)
                                StartCoroutine("espera");

                            rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                            nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                            actual = actual.GetComponent<WaypointManager>().hijos[rand];
                        }

                    }
                    break;

                case "Arco(Clone)":
                    if (contador == 0 || contador == vueltas)
                    {
                        vueltas = Random.Range(0, 4);
                        contador = 0;
                    }


                    if (!encontrado)
                    {
                        nav.destination = casa.transform.GetChild(0).position;
                    }
                    else
                    {
                        if (nav.remainingDistance < 3)
                        {
                            paseando = true;
                            contador++;
                            if (contador == vueltas)
                                StartCoroutine("espera");

                            rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                            nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                            actual = actual.GetComponent<WaypointManager>().hijos[rand];   
                        }

                    }
                    break;

                case "Teatro(Clone)":
                    if (contador == 0 || contador == vueltas)
                    {
                        vueltas = Random.Range(0, 4);
                        contador = 0;
                    }


                    if (!encontrado)
                    {
                        nav.destination = casa.transform.GetChild(0).position;
                    }
                    else
                    {
                        if (nav.remainingDistance < 3)
                        {
                            paseando = true;
                            contador++;
                            if (contador == vueltas)
                                StartCoroutine("espera");

                            rand = Random.Range(0, actual.GetComponent<WaypointManager>().hijos.Length);
                            nav.destination = actual.GetComponent<WaypointManager>().hijos[rand].transform.position;
                            actual = actual.GetComponent<WaypointManager>().hijos[rand];
                        }

                    }
                    break;
            }
        }
    }

    IEnumerator espera()
    {
        anim.SetBool("Andando", false);
        nav.Stop();
        transform.LookAt(casa.transform);
        yield return new WaitForSeconds(15f);
        anim.SetBool("Andando", true);
        nav.Resume();
    }
}
