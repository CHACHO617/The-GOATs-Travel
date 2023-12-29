using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD2 : MonoBehaviour
{
    public CharacterController2 characterController;
    public TextMeshProUGUI RightBallText;
    public TextMeshProUGUI LeftBallText;
    public TextMeshProUGUI GoldenText;
    public TextMeshProUGUI HealthText;

    public GameManager1 GameManager1;


    // Update is called once per frame
    void Update()
    {
        RightBallText.text = characterController.BallsMaxR.ToString();
        LeftBallText.text = characterController.BallsMaxL.ToString();
        GoldenText.text = GameManager1.PuntosTotales.ToString() + "/4";
        HealthText.text = GameManager1.TotalHealth.ToString();

        // Set color based on TotalHealth value
        if (GameManager1.TotalHealth >= 80)
        {
            HealthText.color = Color.green;
        }
        else if (GameManager1.TotalHealth >= 30)
        {
            HealthText.color = Color.yellow;
        }
        else if (GameManager1.TotalHealth >= 0)
        {
            HealthText.color = Color.red;
        }
    }
}
