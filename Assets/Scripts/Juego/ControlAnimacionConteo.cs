using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacionConteo : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    public void FinalDelConteo()
    {
        //Debug.Log("Se ejecuta el final del Coteo");
        GameManager.instance.CambioDeEstadoDeJuego(2);
    }
}
