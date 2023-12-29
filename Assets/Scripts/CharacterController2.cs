using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;
    public float fuerzaSalto;
    private BoxCollider2D boxCollider;
    public LayerMask capaSuelo;
    public int saltosMaximos;
    private int saltosrestantes;
    private Animator animator;

    public float moveSpeed = 5.0f;
    public GameObject ball;
    public GameObject ball1;
    public Transform cannonTransform;

    public AudioSource audiosource;
    public GameManager1 GameManager1;


    private int ballsMaxL = 15;
    public int BallsMaxL { get { return ballsMaxL; } }


    private int ballsMaxR = 15;
    public int BallsMaxR { get { return ballsMaxR; } }



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosrestantes = saltosMaximos;
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        GameManager1 = GameObject.FindObjectOfType<GameManager1>();


    }
    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (ballsMaxR > 0)
            {
                FireBullet();
                ballsMaxR--;
            }
            else
            {
                Debug.Log("No more balls");
            }

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (ballsMaxL > 0)
            {
                FireBulletL();
                ballsMaxL--;
            }
            else
            {
                Debug.Log("No more balls");
            }

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Cascaritas();

        }




    }


    public void Cascaritas()
    {
        // Set the boolean to true
        animator.SetBool("isCascaritas1", true);

        // Start a coroutine to set it back to false after 3 seconds
        StartCoroutine(SetCascaritasFalseAfterDelay(3f));
    }



    IEnumerator SetCascaritasFalseAfterDelay(float delay)
    {
        // Wait for the specified delay in seconds
        yield return new WaitForSeconds(delay);

        // Set the boolean back to false
        animator.SetBool("isCascaritas1", false);
    }





    void FireBullet()
    {
        if (ball != null && cannonTransform != null)
        {
            GameObject bullet = Instantiate(ball, cannonTransform.position, cannonTransform.rotation);
        }
    }
    void FireBulletL()
    {
        if (ball != null && cannonTransform != null)
        {
            GameObject bullet = Instantiate(ball1, cannonTransform.position, cannonTransform.rotation);

        }


    }




    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if (EstaEnSuelo())
        {
            saltosrestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosrestantes > 0)
        {
            saltosrestantes--;
            /**/
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }



    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning1", true);
        }
        else
        {
            animator.SetBool("isRunning1", false);

        }




        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        gestionarOrientacion(inputMovimiento);
    }


    void gestionarOrientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flag") && GameManager1.PuntosTotales == 4)
        {
            Cascaritas();
        }
    }

}