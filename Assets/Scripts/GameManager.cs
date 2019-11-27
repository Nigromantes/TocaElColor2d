using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public enum EstadoJuego { Inicio, Preambulo, Juego, GameOver }


    public static GameManager instance;

    //Objetos referidos. 

    public GameObject panelControlDeColores;

    public GameObject imagenIndicador;

    public TextMeshProUGUI textoDePuntos;

    public TextMeshProUGUI textoPuntajeFinal;

    public TextMeshProUGUI textoDeMaximoPuntos;

    public GameObject panelBloqueo;
    //public GameObject panelIntermedio;
    //public TextMeshProUGUI textoListo;    
    //public Button botonElegirNivel;

    //public Button botonIniciarJuego;

    //public TextMeshProUGUI guiaColorATocar;
    //public TextMeshProUGUI tutorial;
    //public TextMeshProUGUI conteo;

    //public TextMeshProUGUI textgameOver;
    //public TextMeshProUGUI textPuntajeFinal;
    //public TextMeshProUGUI  textResultado;

    public GameObject panelInicio;
    public GameObject panelPreambulo;
    public GameObject panelGameOver;
    public GameObject imagenContadorTiempo;
    //public Sprite spriteBomba;
    //public Sprite spriteBonus;
    
    //public int nivelDeJuego;



    private void Awake()
    {

        instance = this; 

    }

    private void Start()
    {
         CambioDeEstadoDeJuego(0);
    }

 
    public void CambioDeEstadoDeJuego(int estadoDeJuego)
    {
        switch (estadoDeJuego)
        {
            case 0:
                EstadoDeJuegoInicio();
                break;
            case 1:
                EstadoDeJuegoPreambulo();
                break;
            case 2:
                EstadoDeJuegoJuego();
                break;
            case 3:
                EstadoDeJuegoGameOver();
                break;
            default:
                EstadoDeJuegoInicio();
                break;
        }

    }

  
    private void EstadoDeJuegoInicio()
    {
        panelInicio.SetActive(true);
        panelBloqueo.SetActive(true);
     
    }

    private void EstadoDeJuegoPreambulo()
    {
        panelInicio.SetActive(false);
        panelGameOver.SetActive(false);
        panelPreambulo.SetActive(true);
        panelControlDeColores.GetComponent<ControlPanelColores>().AsignacionDeColorATocar();
        panelControlDeColores.GetComponent<ControlPanelColores>().ReiniciarTiempoMaximo();

        //Actviar el indiciador del color. 

    }

    private void EstadoDeJuegoJuego()
    {
        panelPreambulo.SetActive(false);
        panelBloqueo.SetActive(false);
        panelControlDeColores.GetComponent<ControlPanelColores>().conteoActivo = true;
        
    }

    private void EstadoDeJuegoGameOver()
    {
        panelControlDeColores.GetComponent<ControlPanelColores>().conteoActivo = false;
        panelGameOver.SetActive(true);
        panelBloqueo.SetActive(true);


    }


}
 