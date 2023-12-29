using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    public GameManager1 gameManager;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false; // Ensure "Play On Awake" is disabled
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            DestroyCoin();
        }
    }

    void DestroyCoin()
    {
        audioSource.Play();
        // Turn off the BoxCollider2D
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
        Invoke("DestroyObject", 3f);
        
        Debug.Log("+1");
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
