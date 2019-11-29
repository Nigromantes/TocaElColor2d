using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelColores : MonoBehaviour
{


    //public CuadroColor cuadroColor;
    public CuadroColor[] cuadroColor;
    private int codigoColor;

    int maximoDeCuadros;


    int azules;
    int rojos;
    int amarillos;


    int codigoColorAzul = 1;
    int codigoColorRojo = 2;
    int codigoColorAmarillo = 3;

    int incrementoPuntos;



    public int CodigoColorAzul
    {
        get
        {
            return codigoColorAzul;
        }

        set
        {
            codigoColorAzul = value;
        }
    }

    public int CodigoColorRojo
    {
        get
        {
            return codigoColorRojo;
        }

        set
        {
            codigoColorRojo = value;
        }
    }

    public int CodigoColorAmarillo
    {
        get
        {
            return codigoColorAmarillo;
        }

        set
        {
            codigoColorAmarillo = value;
        }
    }

    public int Azules
    {
        get
        {
            return azules;
        }

        set
        {
            azules = value;
        }
    }

    public int MaximoDeCuadros
    {
        get
        {
            return maximoDeCuadros;
        }

        set
        {
            maximoDeCuadros = value;
        }
    }

    public int Rojos
    {
        get
        {
            return rojos;
        }

        set
        {
            rojos = value;
        }
    }

    public int Amarillos
    {
        get
        {
            return amarillos;
        }

        set
        {
            amarillos = value;
        }
    }

    public int NumeroDeCuadrosQueCambian1
    {
        get
        {
            return numeroDeCuadrosQueCambian1;
        }

        set
        {
            numeroDeCuadrosQueCambian1 = value;
        }
    }

    public int NumeroDeCuadrosQueCambian2
    {
        get
        {
            return numeroDeCuadrosQueCambian2;
        }

        set
        {
            numeroDeCuadrosQueCambian2 = value;
        }
    }

    public int NumeroDeCuadrosQueCambian3
    {
        get
        {
            return numeroDeCuadrosQueCambian3;
        }

        set
        {
            numeroDeCuadrosQueCambian3 = value;
        }
    }


    int numeroDeCuadrosQueCambian1;
    int numeroDeCuadrosQueCambian2;
    int numeroDeCuadrosQueCambian3;

    public int numeroDeCuadrosQueCambian1Totales;
    public int numeroDeCuadrosQueCambian2Totales;
    public int numeroDeCuadrosQueCambian3Totales;

    private int puntos;
    //private int maximoPuntaje;
    private int colorATocar;

    public Sprite sprite_Azul;
    public Sprite sprite_Rojo;
    public Sprite sprite_Amarillo;

    private float tiempoMaximoBase = 1f;
    private float tiempoMaximoModificador = 0f;
    private float tiempoMaximoJuego;

    public bool conteoActivo = false;

    public GameObject botonNivel;


    public float TiempoInicial {

        get
        {
            return tiempoMaximoBase + tiempoMaximoModificador;

        }

    }




    public void DefinirVariables()
    {
        maximoDeCuadros = cuadroColor.Length / 3;

        azules = maximoDeCuadros;
        rojos = maximoDeCuadros;
        amarillos = maximoDeCuadros;

        //numeroDeCuadrosQueCambian = maximoDeCuadros / 4
        NumeroDeCuadrosQueCambian1 = numeroDeCuadrosQueCambian1Totales;
        NumeroDeCuadrosQueCambian2 = numeroDeCuadrosQueCambian2Totales;
        NumeroDeCuadrosQueCambian3 = numeroDeCuadrosQueCambian3Totales;


        AjusteDeModificadorTiempo();

        puntos = 0;
        //maximoPuntaje = 0;
        ReiniciarTiempoMaximo();

    }

    private void AjusteDeModificadorTiempo()
    {
        int nivelDeJuego = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();
        switch (nivelDeJuego)
        {
            case 0:
                tiempoMaximoModificador = 0;
                break;
            case 1:
                tiempoMaximoModificador = -0.10f;
                break;
            case 2:
                tiempoMaximoModificador = -0.25f;
                break;

            default:
                break;
        }
    }

    public void ReiniciarTiempoMaximo()
    {
        tiempoMaximoJuego = TiempoInicial;
    }

    void Start()
    {
        

        DefinirVariables();
        //AsignacionDeColorATocar();
        AsignarColoresAlInicio();
        
    }

    void Update()
    {
        ConteoTiempo();

    }

    private void ConteoTiempo()
    {
        if (conteoActivo)
        {
            tiempoMaximoJuego -= Time.deltaTime;
            if (tiempoMaximoJuego < 0)
            {
                //Debug.Log("Se acabó el tiempo");
                FinDelJuego();
                

            }
            GameManager.instance.imagenContadorTiempo.GetComponent<Image>().fillAmount = (tiempoMaximoJuego);
        }
    }

    public void AsignacionDeColorATocar()
    {
        colorATocar = UnityEngine.Random.Range(1, 4);
        //Debug.Log("Se ejectua el Asignación color");

        switch (colorATocar)
        {
            case 1:
                
                GameManager.instance.imagenIndicador.GetComponent<Image>().sprite = sprite_Azul;

                break;
            case 2:


                //ImageIndicador.GetComponent<Image>().sprite = sprite_Rojo;
                GameManager.instance.imagenIndicador.GetComponent<Image>().sprite = sprite_Rojo;

                break;
            case 3:
                //ImageIndicador.GetComponent<Image>().sprite = sprite_Rojo;
                GameManager.instance.imagenIndicador.GetComponent<Image>().sprite = sprite_Amarillo;

                break;
        }
    }
    public void AsignarColoresAlInicio()
    {
        for (int i = 0; i < cuadroColor.Length; i++)
        {

            codigoColor = UnityEngine.Random.Range(1, 4);

            switch (codigoColor)
            {
                case 1:
                    if (Azules > 0)
                    {
                        Azules = AsignacionColor(i, CodigoColorAzul, Azules);
                    }
                    else if (Rojos > 0)
                    {
                        Rojos = AsignacionColor(i, CodigoColorRojo, Rojos);
                    }
                    else if (Amarillos > 0)
                    {

                        Amarillos = AsignacionColor(i, CodigoColorAmarillo, Amarillos);
                    }

                    break;
                case 2:
                    if (Rojos > 0)
                    {
                        Rojos = AsignacionColor(i, CodigoColorRojo, Rojos);
                    }
                    else if (Amarillos > 0)
                    {
                        Amarillos = AsignacionColor(i, CodigoColorAmarillo, Amarillos);
                    }
                    else if (Azules > 0)
                    {
                        Azules = AsignacionColor(i, CodigoColorAzul, Azules);
                    }

                    break;
                case 3:
                    if (Amarillos > 0)
                    {
                        Amarillos = AsignacionColor(i, CodigoColorAmarillo, Amarillos);
                    }
                    else if (Azules > 0)
                    {
                        Azules = AsignacionColor(i, CodigoColorAzul, Azules);
                    }
                    else if (Rojos > 0)
                    {
                        Rojos = AsignacionColor(i, CodigoColorRojo, Rojos);
                    }

                    break;
            }


        }
    }

    private int AsignacionColor(int i, int codigoDeColor, int cantidadColores)
    {
        cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(codigoDeColor);
        cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = codigoDeColor;
        

        cantidadColores--;
        return cantidadColores;
    }


    public void AjusteDeCololorAlosCuadradosDesdeMangaer(int codigoColorACambiar1, int codigoColorACambiar2, int codigoColorACambiar3)
    {


        for (int i = 0; i < cuadroColor.Length; i++)
        {


            NumeroDeCuadrosQueCambian1 = CambiodeColorPorElmanager(codigoColorACambiar1, i, NumeroDeCuadrosQueCambian1);

            NumeroDeCuadrosQueCambian2 = CambiodeColorPorElmanager(codigoColorACambiar2, i, NumeroDeCuadrosQueCambian2);

            NumeroDeCuadrosQueCambian3 = CambiodeColorPorElmanager(codigoColorACambiar3, i, NumeroDeCuadrosQueCambian3);

        }
        //Ajustar para quede automático este ajuste. 
        NumeroDeCuadrosQueCambian1 = numeroDeCuadrosQueCambian1Totales;
        NumeroDeCuadrosQueCambian2 = numeroDeCuadrosQueCambian2Totales;
        NumeroDeCuadrosQueCambian3 = numeroDeCuadrosQueCambian3Totales;


    }


    private int CambiodeColorPorElmanager(int codigoColorACambiar, int i, int numeroDeCuadrosQueCambian)
    {
        if (cuadroColor[i].GetComponent<CuadroColor>().CodigoColor == (codigoColorACambiar))
        {

            int portecentajeDeCambio = UnityEngine.Random.Range(1, 101);
            //Debug.Log(portecentajeDeCambio);
            if (numeroDeCuadrosQueCambian > 0 && portecentajeDeCambio > 50)
            {
                //Debug.Log("CodigoColorAcambiar: " + codigoColorACambiar);
                int cambiodColor = AjusteCodigoColorACambiar(codigoColorACambiar);

                numeroDeCuadrosQueCambian = CambioColor(i, cambiodColor, numeroDeCuadrosQueCambian);
                //Debug.Log("Se cambio el cuadro: " + i +"CodigoColorfinal: "+ cambiodColor);
            }

        }
        return numeroDeCuadrosQueCambian;
    }

    private int CambioColor(int i, int cambiodColor, int numeroDeCuadrosQueCambian)
    {
        cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(cambiodColor);
        cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = cambiodColor;

        cuadroColor[i].GetComponent<CuadroColor>().ReiniciarModificadores();
        cuadroColor[i].GetComponent<CuadroColor>().DefinirModificador();


        numeroDeCuadrosQueCambian--;
        return numeroDeCuadrosQueCambian;
    }



    int AjusteCodigoColorACambiar(int codigoColor)
    {
        codigoColor++;
        if (codigoColor > 3)
        {
            codigoColor = 1;
        }
        return codigoColor;


    }

    public void ManejoDePuntaje(int codigoColor,int modificador)
    {
       //int incrementoPuntos;

        switch (modificador)
        {
            case 0: incrementoPuntos = 1; break;
            case 1: incrementoPuntos = -8; break;
            case 2: incrementoPuntos = 4; break;
            default: incrementoPuntos = 1; break;
        }


        if (codigoColor == colorATocar)
        {
            puntos+=incrementoPuntos;
            ReiniciarTiempoMaximo();
        }
        else
        {
            //if (puntos > maximoPuntaje)
            //{
            //    maximoPuntaje = puntos;
            //}

            FinDelJuego();
        }

        AjusteDeTextoPuntajeActivo();
    }

    private void FinDelJuego()
    {
        int nivelActual = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();
        GuardadoDePuntajeEnBaseDedatos();
        AjusteDeTextoPuntaFinal();
        puntos = 0;
        //AsignacionDeColorATocar();            
        GameManager.instance.CambioDeEstadoDeJuego(3);        
        botonNivel.GetComponent<BotonNivel>().AjusteDeTextoRecord(nivelActual); ;     
    }

    private void GuardadoDePuntajeEnBaseDedatos()
    {
        //Debug.Log("Se ejecuta el método guardado de puntaje en base de datos");

        int nivelActual = GameManager.instance.GetComponent<BaseDatosMaganer>().CargarNivel();
        string nombre = GameManager.instance.GetComponent<BaseDatosMaganer>().EncontrarNombreActivo();
        string tablaNivel = "";
        
        switch (nivelActual)
        {
            case 0: tablaNivel = "PuntajesNivelFacil";
                break;
            case 1:
                tablaNivel = "PuntajesNivelMedio";
                break;
            case 2:
                tablaNivel = "PuntajesNivelDificil";
                break;
        }
        //Debug.Log(tablaNivel);
        
        GameManager.instance.GetComponent<BaseDatosMaganer>().InsertarPuntos(tablaNivel, nombre,puntos);
    }

    private void AjusteDeTextoPuntajeActivo()
    {
        GameManager.instance.textoDePuntos.text = "Puntos: " + puntos;
      
       
    }

    private void AjusteDeTextoPuntaFinal()
    {
        //Debug.Log("Se ejecuta el ajuste de texto puntaje final");
        
        GameManager.instance.textoPuntajeFinal.text = "Puntos: " + puntos;

    }
}
