using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLeft : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 100f;
    private Vector3 initialPosition;

    public GameObject explosion1;



    // Start is called before the first frame update
    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.left * speed * Time.deltaTime);


        if (Vector3.Distance(initialPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explosion1, transform.position, Quaternion.identity);
            Debug.Log("Colisiono Con Jugador");
        }
    }
}