using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class EdificioColocable : MonoBehaviour {
    [HideInInspector]public List<Collider> colliders = new List<Collider>();

    public void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Edificio")
        {
            colliders.Add(c);
        }
    }
    public  void OnTriggerExit(Collider c)
    {
        if (c.tag == "Edificio")
        {
            colliders.Remove(c);
        }
    }
}
