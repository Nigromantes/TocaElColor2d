using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonGuardarNombre : MonoBehaviour {


    private BaseDatosMaganer baseDatosMaganer;


    void Start()
    {
        baseDatosMaganer = GetComponent<BaseDatosMaganer>();

    }
    
    public void GuardarNombreBaseDatos()
    {
        string nombreIngresdo = GameManagerInicio.instance.textoNombreIngresado.GetComponent<Text>().text;


        baseDatosMaganer.SetearNombreInactivo();
        baseDatosMaganer.InsertarNombre(nombreIngresdo);

        if (GameManagerInicio.instance.panelBaseDatosNombres.activeInHierarchy == true)
        {
            //Debug.Log("crea el nombre solo");
            baseDatosMaganer.CrearNombreUnicoEnBaseDatos(nombreIngresdo);
        }

        //GameManagerInicio.instance.textoNombreIngresado.GetComponent<Text>().text = "";
        GameManagerInicio.instance.panelNombres.SetActive(false);
        GameManagerInicio.instance.panelGuardarNombre.SetActive(false);
        GameManagerInicio.instance.textoSaludo.GetComponent<TextoSaludo>().StearTextoSaludo();
        

    }
    
}
