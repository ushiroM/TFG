using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdificioArrastrable : MonoBehaviour {
    public bool salido = false;

	public void OnMouseExit()
    {
        salido = true;
    }
}
