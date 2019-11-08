using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextoSaludo : MonoBehaviour {

    public BaseDatosMaganer baseDatosMaganer;
    private TextMeshProUGUI textSaludo;
    private string nombre;

    public static TextoSaludo instace;


    void Awake()
    {
        instace = this;

    }


    // Use this for initialization
    void Start()
    {
        StearTextoSaludo();

    }

    public void StearTextoSaludo()
    {
        textSaludo = GetComponent<TextMeshProUGUI>();

        nombre = baseDatosMaganer.EncontrarNombreActivo("*", "Nombres", "Activo", "=", "1");


        if (nombre != "nombre")
        {
            textSaludo.text = "Hello " + nombre+"!";

        }
        else
        {
            //Debug.Log("Se ejecuta la activacion de panel");
            
            GameManager2.instance.GetComponent<GameManager2>().panelGuardarNombre.SetActive(true);
        }

    }
}
