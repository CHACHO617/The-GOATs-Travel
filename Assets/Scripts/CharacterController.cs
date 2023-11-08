using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
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



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosrestantes = saltosMaximos;
        animator = GetComponent<Animator>();    

    }
    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();

        if (Input.GetKeyDown(KeyCode.K))
        {
            FireBullet();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            FireBulletL();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Cascaritas(); 
            
        }

        
              
        
    }

   
        void Cascaritas()
        {
            // Set the boolean to true
            animator.SetBool("isCascaritas", true);

            // Start a coroutine to set it back to false after 3 seconds
            StartCoroutine(SetCascaritasFalseAfterDelay(3f));
        }       

    

    IEnumerator SetCascaritasFalseAfterDelay(float delay)
    {
        // Wait for the specified delay in seconds
        yield return new WaitForSeconds(delay);

        // Set the boolean back to false
        animator.SetBool("isCascaritas", false);
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

        if(Input.GetKeyDown(KeyCode.Space) && saltosrestantes>0)
        {
            saltosrestantes--;
            /**/rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }



    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        
        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);

        }




        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        gestionarOrientacion(inputMovimiento);
    }


    void gestionarOrientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == true && inputMovimiento < 0) || mirandoDerecha == false && inputMovimiento>0) 
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
