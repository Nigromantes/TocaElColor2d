using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonEliminar : MonoBehaviour {


    
    public bool BotonEliminarActivo = false;
    


    private PanelDatosNombres panelDatosNombres;

    private void Start()
    {

        panelDatosNombres = GetComponent<PanelDatosNombres>();
    }

   public void AcitvarBoton()
    {
        if (BotonEliminarActivo)
        {
            BotonEliminarActivo = false;
            //Debug.Log("Boton Inactivo");
            
            DesactivarEliminacion();

        }
        else
        {

            BotonEliminarActivo = true;
            // Debug.Log("Boton Activo");
            ActivarEliminacion();
            
        }

    }
       
       
    public void ActivarEliminacion()
    {

        panelDatosNombres.elegir = false;       
        GameManagerInicio.instance.panelCambioColorElimnacion.SetActive(true);

       

    }


    public void DesactivarEliminacion()
    {

        panelDatosNombres.elegir = true;
        GameManagerInicio.instance.panelCambioColorElimnacion.SetActive(false);



    }

    //public void AjustarPanelColorEliminar()
    //{
    //    GameManagerInicio.instance.panelCambioColorElimnacion.gameObject.transform.transform.localScale

    //}

}
