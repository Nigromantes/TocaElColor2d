using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlNombresBaseDatos : MonoBehaviour,IPointerDownHandler{

  
   private Text textNombre;
    

   
      
    private void Start()
    {
        textNombre = GetComponentInChildren<Text>();
        
       
        
    }

 
    public void TocarNombreEnElPanel()
    {
        if (GameManagerInicio.instance.GetComponent<PanelDatosNombres>().elegir)
        {


            //Debug.Log("Se elige el nombre");
           GameManagerInicio.instance.GetComponent<BaseDatosMaganer>().SetearNombreInactivo();
           GameManagerInicio.instance.GetComponent<BaseDatosMaganer>().SetearNombreActivo(textNombre.text);

           GameManagerInicio.instance.panelNombres.transform.gameObject.SetActive(false);            
           GameManagerInicio.instance.textoSaludo.GetComponent<TextoSaludo>().StearTextoSaludo();
        }
        else
        {
            //Debug.Log("Se elimina el nombre"); 
            GameManagerInicio.instance.GetComponent<BaseDatosMaganer>().BorrarNombre(textNombre.text);
            Destroy(gameObject);
            

        }

    }

 

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Se ejecutó On Mouse Down");
        TocarNombreEnElPanel();
    }
}

