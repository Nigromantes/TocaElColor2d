using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BotonNivel : MonoBehaviour {


    //int nivelActual = GameManager.instance.nivelDeJuego;
    private Transform transformTextoNivelHijo;
    //private TextMeshProUGUI textoNivel;
    public TextMeshProUGUI textoNivel;
    private string TextoDeElNivelActual;

    private void Start()
    {
        //transformTextoNivelHijo = this.gameObject.transform.GetChild(0);
        //textoNivel = transformTextoNivelHijo.GetComponent<TextMeshProUGUI>();
        TextoDeElNivelActual = DeterminarTextoActualNivel();
        AjusteNivel(GameManager.instance.nivelDeJuego, TextoDeElNivelActual);

    }


    public void ComportamientoBotonNivel()
    {
        int nuevoNivel = 0;
        switch (GameManager.instance.nivelDeJuego)
        {
            case 0: nuevoNivel = 1;
                break;
            case 1:
                nuevoNivel = 2;
                break;
            case 2:
                nuevoNivel = 0;
                break;
            default:
                break;
        }


        TextoDeElNivelActual = DeterminarTextoNuevoNivel();
        AjusteNivel(nuevoNivel, TextoDeElNivelActual);

    }

    private void AjusteNivel(int nuevoNivel, string textoNuevoNivel)
    {
        GameManager.instance.nivelDeJuego = nuevoNivel;
        textoNivel.text = textoNuevoNivel;
                     
    }

    private string DeterminarTextoActualNivel()
    {
        string textoSegunNivel ="";

        switch (GameManager.instance.nivelDeJuego)
        {
            case 0:
                    textoSegunNivel = "Easy";
                break;
            case 1:
                    textoSegunNivel = "Midium";
                break;
            case 2:
                    textoSegunNivel = "Hard";
                break;

            default:
                textoSegunNivel = "wtf?";
                break;
        }

        return textoSegunNivel;
    }


    private string DeterminarTextoNuevoNivel()
    {
        string textoSegunNivel = "";

        switch (GameManager.instance.nivelDeJuego)
        {
            case 0:
                textoSegunNivel  = "Medium";
                
                break;
            case 1:
                textoSegunNivel = "Hard";
                break;
            case 2:
                textoSegunNivel = "Easy";
                break;

            default:
                textoSegunNivel = "wtf?";
                break;
        }

        return textoSegunNivel;
    }
}
