using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextoSaludo : MonoBehaviour {

    public BaseDatosMaganer baseDatosMaganer;
    private TextMeshProUGUI textSaludo;
    private string nombre;


    // Use this for initialization
    void Start()
    {

        textSaludo = GetComponent<TextMeshProUGUI>();

        nombre = baseDatosMaganer.EncontrarNombreActivo("*", "Nombres", "Activo", "=", "1");
        textSaludo.text = "Hello: " + nombre;
               

    }
}
