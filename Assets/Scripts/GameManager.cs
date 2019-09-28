using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
   public CuadroColor cuadroColor;


    void Start() {

        cuadroColor.GetComponent<CuadroColor>().AjusteColor(2);
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
