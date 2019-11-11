using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerInicio : MonoBehaviour {

    public static GameManagerInicio instance;
    public GameObject panelNombres;
    public GameObject panelGuardarNombre;
    public GameObject panelBaseDatosNombres;

    public GameObject panelCambioColorElimnacion;

    public GameObject textoSaludo;
    public GameObject textNombreIngresado;
    public Text textoNombreIngresado; 
    

    // Use this for initialization
    void Start()
    {

        instance = this;

    }
}
