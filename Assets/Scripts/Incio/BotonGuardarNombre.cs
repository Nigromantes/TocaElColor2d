using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonGuardarNombre : MonoBehaviour {

    public GameObject gameManager2;
    public Text textNombre;
    public GameObject panel; 
    public GameObject panel2; 


    public void GuardarNombreBaseDatos()
    {
        gameManager2.GetComponent<BaseDatosMaganer>().InsertarNombre(textNombre.text);
        panel.SetActive(false);
        panel2.SetActive(false);
        

    }


    
}
