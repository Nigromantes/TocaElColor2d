using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NombreScript : MonoBehaviour {

    public GameObject Nombre;

    public void AplicarNombre(string nombre)
    {

        this.Nombre.GetComponent<Text>().text = nombre;
    }
        
  
}
