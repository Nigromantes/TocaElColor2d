using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    //public CuadroColor cuadroColor;
    public CuadroColor[] cuadroColor;
    private int codigoColor;

    
    int azules; 
    int rojos;
    int amarillos;
    int maximoDeCuadros;

    int codigoColorAzul = 1;
    int codigoColorRojo = 2;
    int codigoColorAmarillo = 3;


    void Awake()
    {

        maximoDeCuadros = cuadroColor.Length/3;

         azules = maximoDeCuadros;
         rojos = maximoDeCuadros;
         amarillos = maximoDeCuadros;


    }



    void Start()
    {

        //cuadroColor.GetComponent<CuadroColor>().AjusteColor(2);

        for (int i = 0; i < cuadroColor.Length; i++)
        {

            codigoColor = UnityEngine.Random.Range(1, 4);

            switch (codigoColor)
            {
                case 1:
                    if (azules > 0)
                    {
                       azules = AsignacionColor(i,codigoColorAzul,azules);
                    }
                    else if (rojos > 0)
                    {
                        rojos = AsignacionColor(i, codigoColorRojo, rojos);
                    }
                    else if (amarillos > 0)
                    {

                        amarillos = AsignacionColor(i,codigoColorAmarillo,amarillos);
                    }

                    break;
                case 2:
                    if (rojos > 0)
                    {
                        rojos = AsignacionColor(i, codigoColorRojo, rojos);
                    }
                    else if (amarillos > 0)
                    {
                        amarillos = AsignacionColor(i,codigoColorAmarillo,amarillos);
                    }
                    else if (azules > 0)
                    {
                        azules = AsignacionColor(i,codigoColorAzul,azules);
                    }

                    break;
                case 3:
                    if (amarillos > 0)
                    {
                         amarillos = AsignacionColor(i,codigoColorAmarillo,amarillos);
                    }
                    else if (azules > 0)
                    {
                        azules = AsignacionColor(i,codigoColorAzul,azules);
                    }
                    else if (rojos > 0)
                    {
                        rojos = AsignacionColor(i, codigoColorRojo, rojos);
                    }

                    break;
            }


        }
    }

    private int AsignacionColor(int i,  int codigoDeColor, int cantidadColores)
    {
        cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(codigoDeColor);
        cantidadColores--;
        return cantidadColores;
    }

    //private void SwittchColores(int i, int codigoColor, int azules, int rojos, int amarillos)
    //{
    //    switch (codigoColor)
    //    {
    //        //case 1: cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(codigoColor);
    //        //    azules++;
    //        //    break;
    //        case 1:
    //            AsignacionDecolor(i, codigoColor, azules);
    //            break;
    //        case 2:
    //            AsignacionDecolor(i, codigoColor, rojos);
    //            break;
    //        case 3:
    //            AsignacionDecolor(i, codigoColor, amarillos);
    //            break;

    //    }
    //}

    //void AsignacionDecolor(int i, int codigoColor, int color )
    //{
    //    cuadroColor[i].GetComponent<CuadroColor>().AjusteColor(codigoColor);
    //    color++;

    //}






    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
