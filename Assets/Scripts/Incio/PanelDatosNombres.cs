using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDatosNombres : MonoBehaviour {

    private BaseDatosMaganer baseDatosMaganer;
    
    
    // Use this for initialization
	void Start () {
        baseDatosMaganer = GetComponent<BaseDatosMaganer>();
        baseDatosMaganer.MostrarNombres();
	}
	
	
}
