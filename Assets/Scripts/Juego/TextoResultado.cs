using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoResultado : MonoBehaviour {


    public TextMeshProUGUI textoResultado;
    private string resultado = "Resultado";
    
 //   // Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    //Acá habrá un método que se calculará según el puntaje. 
    //
    public void DefinirTextoResultado(int puntajeFinal)
    {
        int indiceResultado = 0;
      
       

        //int RecordActual = ObtenerRecordActual();

        //Debug.Log("Record Actual: " + RecordActual);

        //if (RecordActual < 100)
        //{
        //    Debug.Log("Se ejecuta menos de 100");
        //    indiceResultado = DefinirIndiceResultadoMenosde100(puntajeFinal, indiceResultado);
        //}
        //else
        //{
        //    Debug.Log("Se ejecuta más de 100");
        //    indiceResultado = DefinirIndiceResultadoMasde100(puntajeFinal, indiceResultado);

        //}

        indiceResultado = ObtenerIndiceResultado(puntajeFinal);

        //Debug.Log(indiceResultado);

        switch (indiceResultado)
        {
            case 0:
                resultado = "Improvable";
                break;
            case 1:
                resultado = "Acceptable";
                break;
            case 2:
                resultado = "Good";
                break;
            case 3:
                resultado = "Excellent";
                break;
            case 4:
                resultado = "Amazing";
                break;
            case 5:
                resultado = "New Record";
                break;

        }

        textoResultado.text = resultado;

    }

   
    private static int ObtenerRecordActual()
    {
        string tablaNivel = "";
        int nivelActual = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();

        switch (nivelActual)
        {
            case 0:
                tablaNivel = "PuntajesNivelFacil";
                break;
            case 1:
                tablaNivel = "PuntajesNivelMedio";
                break;
            case 2:
                tablaNivel = "PuntajesNivelDificil";
                break;
        }

        int record = GameManager.instance.GetComponent<BaseDatosMaganer>().ObtenerRecord(tablaNivel);

        return record; 
    }

    //private static int DefinirIndiceResultadoMasde100(int puntajeFinal, int indiceResultado)
    //{
        
    //    int recordActual = ObtenerRecordActual();

    //    if (recordActual <100)
    //    {
    //        recordActual = 100;
    //    }


    //    int fraccionPuntaje = (recordActual / 5);

    //    Debug.Log("Francion de puntaje:"+fraccionPuntaje);


    //    if (puntajeFinal > 0 && puntajeFinal < (fraccionPuntaje * 1) )
    //    {
    //        indiceResultado = 0;

    //    }
    //    if (puntajeFinal > (fraccionPuntaje * 1) && puntajeFinal < (fraccionPuntaje * 2))
    //    {
    //        indiceResultado = 1;

    //    }
    //    if (puntajeFinal > (fraccionPuntaje * 2) && puntajeFinal < (fraccionPuntaje * 3))
    //    {
    //        indiceResultado = 2;

    //    }
    //    if (puntajeFinal > (fraccionPuntaje * 3) && puntajeFinal < (fraccionPuntaje * 4))
    //    {
    //        indiceResultado = 3;

    //    }
    //    if (puntajeFinal > (fraccionPuntaje * 4) && puntajeFinal < (fraccionPuntaje * 5))
    //    {
    //        indiceResultado = 4;

    //    }
    //    if (puntajeFinal > (recordActual))
    //    {
    //        indiceResultado = 5;

    //    }
         
    //    return indiceResultado;
    //}


    private int ObtenerIndiceResultado( int puntajeFinal)
    {
        int indiceResultado = 0; 
        int recordActual = ObtenerRecordActual();

        if (recordActual < 100)
        {
            recordActual = 100;
        }


        int fraccionPuntaje = (recordActual / 5);

        //Debug.Log("Fracion de puntaje:" + fraccionPuntaje);


        if (/*puntajeFinal > 0 && */puntajeFinal < (fraccionPuntaje * 1))
        {
            indiceResultado = 0;

        }
        if (puntajeFinal > (fraccionPuntaje * 1) && puntajeFinal < (fraccionPuntaje * 2))
        {
            indiceResultado = 1;

        }
        if (puntajeFinal > (fraccionPuntaje * 2) && puntajeFinal < (fraccionPuntaje * 3))
        {
            indiceResultado = 2;

        }
        if (puntajeFinal > (fraccionPuntaje * 3) && puntajeFinal < (fraccionPuntaje * 4))
        {
            indiceResultado = 3;

        }
        if (puntajeFinal > (fraccionPuntaje * 4) && puntajeFinal < (fraccionPuntaje * 5))
        {
            indiceResultado = 4;

        }
        if (puntajeFinal > (recordActual))
        {
            indiceResultado = 5;

        }

        return indiceResultado;
        
    }



    //private static int DefinirIndiceResultadoMenosde100(int puntajeFinal, int indiceResultado)
    //{
    //    if (puntajeFinal < 20)
    //    {
    //        indiceResultado = 0;

    //    }
    //    if (puntajeFinal > 40 && puntajeFinal < 60  )
    //    {
    //        indiceResultado = 1;

    //    }
    //    if (puntajeFinal > 60 && puntajeFinal < 60)
    //    {
    //        indiceResultado = 2;

    //    }
    //    if (puntajeFinal < 80)
    //    {
    //        indiceResultado = 3;

    //    }
    //    if (puntajeFinal < 100)
    //    {
    //        indiceResultado = 4;

    //    }
    //    if (puntajeFinal > 100)
    //    {
    //        indiceResultado = 5;

    //    }

    //    return indiceResultado;
    //}
}
