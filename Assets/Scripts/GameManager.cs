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

    void Awake()
    {

        maximoDeCuadros = cuadroColor.Length / 3;

        azules = maximoDeCuadros;
        rojos = maximoDeCuadros;
        amarillos = maximoDeCuadros;


    }



    void Start()
    {
        //cuadroColor.GetComponent<CuadroColor>().AjusteColor(2);

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

    private int AsignacionColor(int i,  int codigoDeColor, int cantidadColores)
    {
        cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(codigoDeColor);
        cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = codigoDeColor;

        cantidadColores--;
        return cantidadColores;
    }



    public void AjusteDeCololorAlosCuadrados(int codigoColorDeCambio)
    {
        for (int i = 0; i < cuadroColor.Length; i++)
        {

            int numeroDeCuadrosQueCambian = 1;
            if (cuadroColor[i].GetComponent<CuadroColor>().CodigoColor == (codigoColorDeCambio+1))
            {

            }


            switch (codigoColorDeCambio)
            {
                case 1:
                    int CuadroACambiarElejgido;
                    CuadroACambiarElejgido = UnityEngine.Random.Range(1, maximoDeCuadros);
                    //if ( cuadroColor[i].GetComponent<CuadroColor>().CodigoColor = codigoColorDeCambio)
                    //{

                    //}

                   


                    break;
            }


        }



    }




    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
