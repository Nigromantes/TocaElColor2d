﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CuadroColor : MonoBehaviour,IPointerDownHandler {

	
    public enum Color {Azul,Rojo,Amarillo};

 

    public Sprite sprite_Blanco;
    public Sprite sprite_Azul;
    public Sprite sprite_Rojo;
    public Sprite sprite_Amarillo;

    private SpriteRenderer spriteRender;
    private int codigoColor = 0;

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

        spriteRender = GetComponent<SpriteRenderer>();
        //codigoColor = UnityEngine.Random.Range(1, 4);
        //codigoColor = 1; 
        
       AjusteColor(CodigoColor);



    }

    public void AjusteColor(int codigoColor)
    {
        switch (codigoColor)
        {
            case 0: spriteRender.sprite = sprite_Blanco; break;
            case 1: spriteRender.sprite = sprite_Azul; break;
            case 2: spriteRender.sprite = sprite_Rojo; break;
            case 3: spriteRender.sprite = sprite_Amarillo; break;
        }

    }

    // Update is called once per frame
 //   void Update () {
		
	//}


    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Se ejecuta el cambio de color");

        RotacionColor();

    }

    private void RotacionColor()
    {
        if (CodigoColor < 3)
        {
            CodigoColor++;
            AjusteColor(CodigoColor);
        }
        else
        {
            CodigoColor = 1;
            AjusteColor(CodigoColor);
        }


    }
}
