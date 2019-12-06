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
    public TextMeshProUGUI TextoRecord;
    private string TextoRecordDeNivel;
    //int nivelActual;

    private void Start()
    {

      int nivelActual = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();

        //transformTextoNivelHijo = this.gameObject.transform.GetChild(0);
        //textoNivel = transformTextoNivelHijo.GetComponent<TextMeshProUGUI>();
        TextoDeElNivelActual = DeterminarTextoActualNivel(nivelActual);
        //AjusteNivel(nivelActual, TextoDeElNivelActual);
        //AjusteNivel(GameManager.instance.nivelDeJuego, TextoDeElNivelActual);
        AjusteTextoInicial(TextoDeElNivelActual);
        AjusteDeTextoRecord(nivelActual);
       
       
    }


    public void ComportamientoBotonNivel()
    {

        int nivelActual = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();
        int nuevoNivel = 0;
        switch (nivelActual)
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


        TextoDeElNivelActual = DeterminarTextoActualNivel(nuevoNivel);
        AjusteNivel(nuevoNivel, TextoDeElNivelActual);
        AjusteDeTextoRecord(nuevoNivel);

    }

    private void AjusteNivel(int nuevoNivel, string textoNuevoNivel)
    {
        //GameManager.instance.nivelDeJuego = nuevoNivel;
        GameManager.instance.GetComponent<BaseDatosMaganer>().SeteaNivelActivo(nuevoNivel);


        textoNivel.text = textoNuevoNivel;

        //Debug.Log(nuevoNivel);
                     
    }

    private void AjusteTextoInicial(string TextoNivelInicial)
    {

        textoNivel.text = TextoNivelInicial;
    }

  protected string DeterminarTextoActualNivel(int nivelActual)
    {
        string textoSegunNivel ="";

        switch (nivelActual)
        {
            case 0:
                    textoSegunNivel = "Easy";
                break;
            case 1:
                    textoSegunNivel = "Medium";
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

    public void AjusteDeTextoRecord(int nivelActual)
    {
        string tablaDePuntajesNivel = "";

        switch (nivelActual)
        {
            case 0:
                tablaDePuntajesNivel = "PuntajesNivelFacil";
                break;
            case 1:
                tablaDePuntajesNivel = "PuntajesNivelMedio";
                break;
            case 2:
                tablaDePuntajesNivel = "PuntajesNivelDificil";
                break;

        }

        int record = GameManager.instance.GetComponent<BaseDatosMaganer>().ObtenerRecord(tablaDePuntajesNivel);
        TextoRecord.text = "Record: " + record;
       
    }
}
