using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeTableScript : MonoBehaviour{

    public GameObject Indice;
    public GameObject Nombre;
    public GameObject Puntos;

    public void AsignarInformacion(string posicion, string nombre, string puntos)
    {
        this.Indice.GetComponent<Text>().text = posicion;
        this.Nombre.GetComponent<Text>().text = nombre;
        this.Puntos.GetComponent<Text>().text = puntos;

    }



}
