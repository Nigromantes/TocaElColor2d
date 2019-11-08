using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonGuardarNombre : MonoBehaviour {

    public GameObject gameManager2;
    public Text textNombre;
    public GameObject panelNombres; 
    public GameObject panelGuardarNombre;
    public GameObject textoSaludo;
    public GameObject panelBaseDatosNombres;
    
    public void GuardarNombreBaseDatos()
    {
        gameManager2.GetComponent<BaseDatosMaganer>().SetearNombreInactivo();
        gameManager2.GetComponent<BaseDatosMaganer>().InsertarNombre(textNombre.text);

        //gameManager2.GetComponent<BaseDatosMaganer>().CrearNOmbreUnicoEnBaseDatos(textNombre.text);
        if (panelBaseDatosNombres.activeInHierarchy == true)
        {
            gameManager2.GetComponent<BaseDatosMaganer>().CrearNOmbreUnicoEnBaseDatos(textNombre.text);
        }

        panelNombres.SetActive(false);
        panelGuardarNombre.SetActive(false);
        textoSaludo.GetComponent<TextoSaludo>().StearTextoSaludo();
        

    }

   

}
