using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    public int TotalHealth
    {
        get { return totalHealth; }
        set { totalHealth = value; }
    }

    private int puntosTotales;
    private int totalHealth = 100; // Set the initial value to 100

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }

    void Update()
    {
        if (totalHealth == 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene("Menu");
        }

    }
}

