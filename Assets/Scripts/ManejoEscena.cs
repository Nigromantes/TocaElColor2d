using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscena : MonoBehaviour {


    public void CambioDeEscena(int escena)
    {

        SceneManager.LoadScene(escena);

    }

    void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // AsignarColoresAlInicio();
    }


}
