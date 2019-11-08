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
        if (PanelDatosNombres.instance.elegir)
        {
           
           GameManager2.instance.GetComponent<BaseDatosMaganer>().SetearNombreInactivo();
           GameManager2.instance.GetComponent<BaseDatosMaganer>().InsertarNombre(textNombre.text);

           PanelDatosNombres.instance.transform.gameObject.SetActive(false);            
            TextoSaludo.instace.GetComponent<TextoSaludo>().StearTextoSaludo();
        }
        else
        {
            GameManager2.instance.GetComponent<BaseDatosMaganer>().BorrarNombre(textNombre.text);
            Destroy(gameObject);
            

        }

    }

 

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Se ejecutó On Mouse Down");
        TocarNombreEnElPanel();
    }
}

