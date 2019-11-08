using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonEliminar : MonoBehaviour {


    public GameObject panelCambioColorElimnacion;
    public bool BotonEliminarActivo = false;

  
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

        PanelDatosNombres.instance.elegir = false;
        panelCambioColorElimnacion.SetActive(true);

       

    }


    public void DesactivarEliminacion()
    {

        PanelDatosNombres.instance.elegir = true;
        panelCambioColorElimnacion.SetActive(false);



    }

}
