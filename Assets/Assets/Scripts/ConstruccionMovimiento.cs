using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private Transform edificio;
    private bool colocado;
    private EdificioColocable edificioColocable;
    // Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if(edificio != null && !colocado)
        {
            edificioColocable = edificio.GetComponent<EdificioColocable>();
            Vector3 raton = Input.mousePosition;
            raton = new Vector3(raton.x, raton.y, transform.position.y);
            Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(raton);
            edificio.position = new Vector3(p.x,0,p.z);

            

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    colocado = true;
                }
            }

        }
       
	}

    bool IsLegalPosition()
    {
        Debug.Log("entro");
        if (edificioColocable.colliders.Count > 0)
            return false;
        return true;
    }

    public void SetItem(GameObject b)
    {
        colocado = false;
        edificio = Instantiate(b).transform;
        edificioColocable = edificio.GetComponent<EdificioColocable>();
    }
}
