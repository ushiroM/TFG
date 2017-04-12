using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private Transform edificio;
    private bool colocado;
    private EdificioColocable edificioColocable;
    private RaycastHit hit;
    private bool posicionado = false;

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

          
            if (Physics.Raycast(edificio.position, -edificio.up, out hit, 10f))
            {
                posicionado = true;
            }
            else
            {
                posicionado = false;
                edificio.position -= new Vector3(edificio.position.x, edificio.position.y - 5, edificio.position.z);
            }
                

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
        if (edificioColocable.colliders.Count > 0 && !posicionado)
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
