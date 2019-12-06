using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlTextoNivel : MonoBehaviour {

    public TextMeshProUGUI textoTablaPuntajes;
    private BaseDatosMaganer baseDatosManager;


    // Use this for initialization
    void Start () {

        baseDatosManager = GetComponent<BaseDatosMaganer>();

        int nivelActual = baseDatosManager.CargarNivel();
        string TextoTablaNivel =   DeterminarTextoActualNivel(nivelActual);
        textoTablaPuntajes.text = TextoTablaNivel;

    }

    private string DeterminarTextoActualNivel(int nivelActual)
    {
        string textoSegunNivel = "";

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
}
