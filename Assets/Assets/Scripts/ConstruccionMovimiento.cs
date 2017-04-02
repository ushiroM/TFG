using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private Transform edificio;
    private bool colocado;
    private EdificioColocable edificioColocable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(edificio != null && !colocado)
        {
            Vector3 raton = Input.mousePosition;
            raton = new Vector3(raton.x, raton.y, transform.position.y);
            Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(raton);
            edificio.position = new Vector3(p.x,0,p.y);
       
        }
        if (Input.GetMouseButtonDown(0))
          //  if(IsLegalPosition())
                colocado = true;
		
	}

    bool IsLegalPosition()
    {
        if (edificioColocable.colliders.Count > 0)
            return false;
        return true;
    }

    public void SetItem(GameObject b)
    {
        colocado = false;
        edificio = ((GameObject)Instantiate(b)).transform;
        edificioColocable = edificio.GetComponent<EdificioColocable>();
    }
}
