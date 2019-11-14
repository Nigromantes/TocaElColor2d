using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class GameManager : MonoBehaviour {

    public static GameManager instance;

    //Objetos referidos. 

    public GameObject panelControlDeColores; 

    public GameObject imagenIndicador; 

    public TextMeshProUGUI textoDePuntos; 

    public TextMeshProUGUI textoPuntajeFinal;

    public TextMeshProUGUI textoDeMaximoPuntos;



    private void Awake()
    {

        instance = this; 

    }

}
 