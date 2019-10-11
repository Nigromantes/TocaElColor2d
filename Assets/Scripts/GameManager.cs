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


    public int numeroDeCuadrosQueCambian1;
    public int numeroDeCuadrosQueCambian2;

    public static GameManager instance;
    void Awake()
    {

        maximoDeCuadros = cuadroColor.Length / 3;

        azules = maximoDeCuadros;
        rojos = maximoDeCuadros;
        amarillos = maximoDeCuadros;

        //numeroDeCuadrosQueCambian = maximoDeCuadros/4
        numeroDeCuadrosQueCambian1 = 1;
        numeroDeCuadrosQueCambian2 = 1;

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



    public void AjusteDeCololorAlosCuadradosDesdeMangaer(int codigoColorACambiar1,int codigoColorAcambiar2)
    {


        for (int i = 0; i < cuadroColor.Length; i++)
        {
            
            if (cuadroColor[i].GetComponent<CuadroColor>().CodigoColor == (codigoColorACambiar1))
            {
                int portecentajeDeCambio = Random.Range(1, 101);
                //Debug.Log(portecentajeDeCambio);
                if (numeroDeCuadrosQueCambian1 > 0 && portecentajeDeCambio > 50)
                {

                    int cambiodColor = AjusteCodigoColorACambiar(codigoColorACambiar1);
                    

                    //cuadroColor[i].AjusteColor(codigoColor);
                    cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(cambiodColor);
                     cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = cambiodColor;
                    numeroDeCuadrosQueCambian1--;
                }
            }

            if (cuadroColor[i].GetComponent<CuadroColor>().CodigoColor == (codigoColorAcambiar2))
            {
                int portecentajeDeCambio = Random.Range(1, 101);
                //Debug.Log(portecentajeDeCambio);
                if (numeroDeCuadrosQueCambian2 > 0 && portecentajeDeCambio > 50)
                {

                    int cambiodColor = AjusteCodigoColorACambiar(codigoColorAcambiar2);


                    //cuadroColor[i].AjusteColor(codigoColor);
                    cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(cambiodColor);
                    cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = cambiodColor;
                    numeroDeCuadrosQueCambian2--;
                }
            }



        }

        //Ajustar para quede automático este ajuste. 
        numeroDeCuadrosQueCambian1 = 1;
        numeroDeCuadrosQueCambian2 = 1;

    }


    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    int AjusteCodigoColorACambiar(int codigoColor)
    {
        codigoColor++;
        if (codigoColor == 4)
        {
            codigoColor = 1;
        }
        return codigoColor;


    }
}
