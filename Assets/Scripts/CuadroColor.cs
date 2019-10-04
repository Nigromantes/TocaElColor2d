using System;
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
    public int codigoColor = 0;
    
    // Use this for initialization
	void Awake() {

        spriteRender = GetComponent<SpriteRenderer>();
        //codigoColor = UnityEngine.Random.Range(1, 4);
        //codigoColor = 1; 
        
       AjusteColor(codigoColor);



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
        if (codigoColor < 3)
        {
            codigoColor++;
            AjusteColor(codigoColor);
        }
        else
        {
            codigoColor = 1;
            AjusteColor(codigoColor);
        }


    }
}
