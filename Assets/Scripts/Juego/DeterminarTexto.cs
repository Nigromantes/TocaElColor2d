using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminarTexto : MonoBehaviour {

	//// Use this for initialization
	//void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    public string DeterminarTextoActualNivel(int nivelActual)
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
