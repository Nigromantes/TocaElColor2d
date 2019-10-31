using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorDelJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Debug.Log("Se ejecuta el Stard del disparador");

        //GameManager.instance.DefinirVariables();
        GameManager.instance.Awake();
        GameManager.instance.AsignacionDeColorATocar();
        GameManager.instance.AsignarColoresAlInicio();
		
	}
	
	
}
