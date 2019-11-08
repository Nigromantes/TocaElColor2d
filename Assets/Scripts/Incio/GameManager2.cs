using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour {


    public static GameManager2 instance;
    public GameObject panelNombres;
    public GameObject panelGuardarNombre;
    
    // Use this for initialization
	void Start () {

        instance = this;
		
	}
	
	
}
