using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionManager : MonoBehaviour {

    public GameObject[] edificios;
    private ConstruccionMovimiento construccionMovimiento;
	// Use this for initialization
	void Start () {
        construccionMovimiento = GetComponent<ConstruccionMovimiento>();
	}
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log("joidfjoisajdf");

	}
    void OnGUI()
    {
        for(int i = 0; i <edificios.Length; i++)
        {
            if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 12 * i, 100, 30), edificios[i].name))
            {
                //Debug.Log("entro");
                construccionMovimiento.SetItem(edificios[i]);
            }
        }
    }
}
