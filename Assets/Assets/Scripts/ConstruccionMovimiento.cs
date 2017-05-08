using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstruccionMovimiento : MonoBehaviour {

    private GameObject edificio;
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
            edificio.transform.position = new Vector3(p.x,edificio.transform.position.y,p.z);

            if (Input.GetMouseButtonDown(0))
            {
                if (IsLegalPosition())
                {
                    colocado = true;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(edificio);
                edificio = null;

            }
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
               edificio.transform.rotation = Quaternion.Lerp(edificio.transform.rotation, edificio.transform.rotation * Quaternion.AngleAxis(90, Vector3.up), 200 * 2f * Time.deltaTime);
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                edificio.transform.rotation = Quaternion.Lerp(edificio.transform.rotation, edificio.transform.rotation * Quaternion.AngleAxis(-90, Vector3.up), 200 * 2f * Time.deltaTime);
            }

        }
       
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
        edificio = Instantiate(b);
        edificioColocable = edificio.GetComponent<EdificioColocable>();
    }
}
