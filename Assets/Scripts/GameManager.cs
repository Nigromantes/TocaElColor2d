using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 


public class GameManager : MonoBehaviour {

    public enum EstadoJuego {Inicio, Preambulo, Juego, GameOver}


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

    public void CambioDeEstadoDeJuego(EstadoJuego estadoDeJuego)
    {
        switch (estadoDeJuego)
        {
            case EstadoJuego.Inicio:
                EstadoDeJuegoInicio();
                break;
            case EstadoJuego.Preambulo:
                EstadoDeJuegoPreambulo();
                break;
            case EstadoJuego.Juego:
                EstadoDeJuegoPreambulo();
                break;
            case EstadoJuego.GameOver:
                EstadoDeJuegoGameOver();
                break;
            default:
                EstadoDeJuegoInicio();
                break;
        }

    }

    private void EstadoDeJuegoInicio()
    {
        //Acá aparece un panel de juego donde el jugador podrá elegir el nivel. 

        //Texto ¿Ready? 
        //Botón de elegir nivel. 
        //Record del nivel
        //Boton Iniciar Juego. 

        //Panel de bloqueo que evita que se activen los cuadros - color antes de tiempo. 

    }

    private void EstadoDeJuegoPreambulo()
    {
        //Se desactiva el panel. 
        //Se activa el texto tutorial. 
        //Se activa un conteo. 

    }

    private void EstadoDeJuegoJuego()
    {
        //Se Activa el juego
        //Se desactiva el panel de bloqueo. 
    }

    private void EstadoDeJuegoGameOver()
    {
        //Se activa el panel intermedio. 
        //Se  desactiva el texto ¿Ready? 
        //Se activa el texto "GameOver"

        //Se activa el panel de bloqueo. 

    }


}
 