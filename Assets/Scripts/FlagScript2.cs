using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class FlagScript2 : MonoBehaviour
{
    public CharacterController characterController;
    private SpriteRenderer spriteRenderer;
    public GameManager1 GameManager1;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager1 = GameObject.FindObjectOfType<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager1.PuntosTotales == 4)
        {
            spriteRenderer.enabled = false;
            Invoke("ChangeScene1", 4f);
        }
        else
        {
            Debug.Log("Falta Recolectar Balones de Oro");
        }
    }

    void ChangeScene1()
    {
        SceneManager.LoadScene("Menu");
    }

}