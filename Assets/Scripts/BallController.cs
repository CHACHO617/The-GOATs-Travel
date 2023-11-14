using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int balls = 0;
    public float speed = 10f;
    public float maxDistance = 100f;
    private Vector3 initialPosition;
    


    // Start is called before the first frame update
    private void Start()
    {
        initialPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.K))
        {
            balls++;
            Debug.Log("++++++++++++" + balls);
        }*/


        transform.Translate(Vector3.right * speed * Time.deltaTime);



        /*if (balls == 3)
        {
            maxDistance = 0f;
        }*/


        if (Vector3.Distance(initialPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Colisiono1");
        }
    }

    


}
