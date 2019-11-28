using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextoSaludo : MonoBehaviour {

    //public BaseDatosMaganer baseDatosMaganer;
    private TextMeshProUGUI textSaludo;
    private string nombre;

    //public static TextoSaludo instace;


    //void Awake()
    //{
    //    instace = this;

    //}


    // Use this for initialization
    void Start()
    {
        StearTextoSaludo();

    }

    public void StearTextoSaludo()
    {
        textSaludo = GetComponent<TextMeshProUGUI>();

        // nombre =  GameManagerInicio.instance.GetComponent<BaseDatosMaganer>().EncontrarNombreActivo("*", "Nombres", "Activo", "=", "1");
        nombre = GameManagerInicio.instance.GetComponent<BaseDatosMaganer>().EncontrarNombreActivo();

        if (nombre != "nombre")
        {
            textSaludo.text = "Hello " + nombre+"!";

        }
        else
        {
            //Debug.Log("Se ejecuta la activacion de panel");
            
            GameManagerInicio.instance.GetComponent<GameManagerInicio>().panelGuardarNombre.SetActive(true);
        }

    }
}
