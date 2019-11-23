using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlImagentiempo : MonoBehaviour {

    // Use this for initialization

    private Image image;

    void Start () {
        image = GetComponent<Image>();
        image.fillAmount = 0.50f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
