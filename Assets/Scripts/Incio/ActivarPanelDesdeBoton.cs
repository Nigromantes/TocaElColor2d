using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivarPanelDesdeBoton : MonoBehaviour {

     //public GameObject panel;


    public void ActivarPanel(GameObject panelParaActivar)
    {
         panelParaActivar.SetActive(true);

    }
}
