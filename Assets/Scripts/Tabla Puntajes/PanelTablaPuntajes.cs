using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTablaPuntajes : MonoBehaviour
{
    private BaseDatosMaganer baseDatosManager;
    
    // Use this for initialization
    void Start()
    {
        baseDatosManager = GetComponent<BaseDatosMaganer>();
        ActivarPanelTablaPuntaje();
    }

    private void ActivarPanelTablaPuntaje()
    {
        baseDatosManager.MostrarPuestosTablaDePuntajes();
        baseDatosManager.BorrarPuntosExtra();
    }
}
