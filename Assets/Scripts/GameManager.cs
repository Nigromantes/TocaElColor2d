using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Use this for initialization
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

    public int numeroDeCuadrosQueCambian1Totales;
    public int numeroDeCuadrosQueCambian2Totales;
    public int numeroDeCuadrosQueCambian3Totales;

    int  numeroDeCuadrosQueCambian1;
    int  numeroDeCuadrosQueCambian2;
    int  numeroDeCuadrosQueCambian3;

    public static GameManager instance;
    void Awake()
    {

        maximoDeCuadros = cuadroColor.Length / 3;

        azules = maximoDeCuadros;
        rojos = maximoDeCuadros;
        amarillos = maximoDeCuadros;

        //numeroDeCuadrosQueCambian = maximoDeCuadros / 4
        NumeroDeCuadrosQueCambian1 = numeroDeCuadrosQueCambian1Totales;
        NumeroDeCuadrosQueCambian2 = numeroDeCuadrosQueCambian2Totales;
        NumeroDeCuadrosQueCambian3 = numeroDeCuadrosQueCambian3Totales;

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }



    }



    void Start()
    {


        AsignarColoresAlInicio();
    }

    private void AsignarColoresAlInicio()
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
            
            int portecentajeDeCambio = Random.Range(1, 101);
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
        numeroDeCuadrosQueCambian--;
        return numeroDeCuadrosQueCambian;
    }


    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        AsignarColoresAlInicio();
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
}
 