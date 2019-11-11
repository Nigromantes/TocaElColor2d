using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDatosNombres : MonoBehaviour {

    private BaseDatosMaganer baseDatosMaganer;
    //public static PanelDatosNombres instance;
    public bool elegir = true;

    //void Awake()
    //{
    //    instance = this;

    //}


    // Use this for initialization
    void Start ()
    {
        baseDatosMaganer = GetComponent<BaseDatosMaganer>();
        ActivarPanelDeNombre();
    }

    public void ActivarPanelDeNombre()
    {
        
        baseDatosMaganer.MostrarNombres();
    }

}
