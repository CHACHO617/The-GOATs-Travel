using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public CharacterController characterController;
    public TextMeshProUGUI RightBallText;
    public TextMeshProUGUI LeftBallText;
    public TextMeshProUGUI GoldenText;

    public GameManager1 GameManager1;


    // Update is called once per frame
    void Update()
    {
        RightBallText.text = characterController.BallsMaxR.ToString();
        LeftBallText.text = characterController.BallsMaxL.ToString();
        GoldenText.text = GameManager1.PuntosTotales.ToString() + "/3";
    }
}
