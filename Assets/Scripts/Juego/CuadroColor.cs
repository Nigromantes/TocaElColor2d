﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;
//using Random = System.Random;

public class CuadroColor : MonoBehaviour, IPointerDownHandler {






    public Sprite sprite_Blanco;
    public Sprite sprite_Azul;
    public Sprite sprite_Rojo;
    public Sprite sprite_Amarillo;

    //private SpriteRenderer spriteRender;
    private Image image;
    private Transform imagenHijo;
    private Image imageModificador;

    private Sprite sprite_Base;
    private int codigoColor = 0;

    private int nivelDeJuego = 1;
    private int modificadorEspecial;

    // 0 = Ninguno. 
    // 1 = Bomba -5 puntos. 
    // 2 = Bono x3 
    public Sprite spriteBomba;
    public Sprite spriteBonus;

    public int CodigoColor
    {
        get
        {
            return codigoColor;
        }

        set
        {
            if (value > 3)
            {
                value = 3;
            }
            else if (value <1)
            {
                value = 1;
            }
            
            codigoColor = value;

            //codigoColor = value;
        }
    }

    // Use this for initialization
    void Awake() {

        // spriteRender = GetComponent<SpriteRenderer>();

        image = GetComponent<Image>();
        imagenHijo = this.gameObject.transform.GetChild(0);

        imageModificador = imagenHijo.GetComponent<Image>();
        




        //codigoColor = UnityEngine.Random.Range(1, 4);
        //codigoColor = 1; 

        AjusteColor(CodigoColor);
       DefinirModificador();

    }

    public void DefinirModificador()
    {

        
        imageModificador.GetComponent<Image>().sprite = spriteBomba;

        int porcentajeLimiteModificador = 5;
        int porcentajeLimiiteDeTipoModificador = 40;
        
        int probailidadDeModifiador;
        
        probailidadDeModifiador = Random.Range(1, 100);
        //Se es menos al porcentaje se vuelve un modificador. 
        if (probailidadDeModifiador< porcentajeLimiteModificador)
        {
            int probabilidadTipoModificador = Random.Range(1, 100);

            if (probabilidadTipoModificador > porcentajeLimiiteDeTipoModificador)
            {
                modificadorEspecial = 1;
                imageModificador.GetComponent<Image>().enabled = true;
                imageModificador.GetComponent<Image>().sprite = spriteBomba;


            }
            else
            {
                modificadorEspecial = 2;
                imageModificador.GetComponent<Image>().enabled = true;
                imageModificador.GetComponent<Image>().sprite = spriteBonus;
            }


        }
        else
        {
            ReiniciarModificadores();

        }



        switch (nivelDeJuego)
        {
            case 1:
                
                break;

            default:
                break;
        }



        //modificadorEspecial = 1;


    }

    public void ReiniciarModificadores()
    {
        imageModificador.GetComponent<Image>().enabled = false;
        modificadorEspecial = 0;
    }

    public void AjusteColor(int codigoColor)
    {
        switch (codigoColor)
        {
            case 0: image.sprite = sprite_Blanco; break;
            case 1: image.sprite = sprite_Azul; break;
            case 2: image.sprite = sprite_Rojo; break;
            case 3: image.sprite = sprite_Amarillo; break;
        }



    }

    // Update is called once per frame
 //   void Update () {
		
	//}


    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Se ejecuta el cambio de color");

        GameManager.instance.panelControlDeColores.GetComponent<ControlPanelColores>().ManejoDePuntaje(codigoColor, modificadorEspecial);


        AsignaciondeCodigoParaCambiodeOtrosCuadros();
        RotacionColor();
        


    }

    private void AsignaciondeCodigoParaCambiodeOtrosCuadros()
    {
        //int codigoColorACamibiar1 = codigoColor;/*AjusteCodigoColorDefinitivo(codigoColor);*/
        //int codigoColorACamibiar2 = codigoColor+2 /AjusteCodigoColor2(codigoColor);
        //int codigoColorACamibiar3 =  AjusteCodigoColor2(codigoColor);;
        ////int codigoColorACamibiar3 = codigoColor;

        int codigoColorACamibiar1 = AjusteCodigoColor1(codigoColor);
        int codigoColorACamibiar2 = AjusteCodigoColor2(codigoColor);
        int codigoColorACamibiar3 = codigoColor;/*AjusteCodigoColor3(codigoColor);*/
         //Debug.Log("codigoColorACamibiar2: " + codigoColorACamibiar2);
        


        GameManager.instance.panelControlDeColores.GetComponent<ControlPanelColores>().AjusteDeCololorAlosCuadradosDesdeMangaer(codigoColorACamibiar1,codigoColorACamibiar2,codigoColorACamibiar3);
    }

    private void RotacionColor()
    {
        if (CodigoColor < 3)
        {
            CodigoColor++;
            
        }
        else
        {
            CodigoColor = 1;
            
        }
        AjusteColor(CodigoColor);

    }

    int AjusteCodigoColor1(int codigoColor)
    {
        codigoColor++;
        if (codigoColor > 3)
        {
            codigoColor = 1;
        }
        return codigoColor;


    }
    int AjusteCodigoColor2(int codigoColor)
    {
      
        switch (codigoColor)
        {
            case 1: codigoColor = 3;
                break;
            case 2:
                codigoColor = 1;
                break;
            case 3:
                codigoColor = 2;
                break;
        }
               
        return codigoColor;
       
    }

    int AjusteCodigoColor3(int codigoColor)
    {
        codigoColor = +3;
        if (codigoColor > 3)
        {
            codigoColor = 1;
        }
        return codigoColor;
    }

    
    


}
