using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void IrAJuego()
    {
        Debug.Log("Entraste al juego");
        SceneManager.LoadScene("SampleScene");
    }

    public void IrALevel1()
    {
        Debug.Log("Entraste al juego");
        SceneManager.LoadScene("Intro1");
    }

    public void IrALevel2()
    {
        Debug.Log("Entraste al nivel2");
        SceneManager.LoadScene("2SampleScene");
    }

    public void RegresarAlMenu()
    {
        Debug.Log("Regresaste al menu");
        SceneManager.LoadScene("Menu");
    }

    public void IrAInstrucciones()
    {
        Debug.Log("Entraste a HTP");
        SceneManager.LoadScene("HowToPlay");
    }
}