using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scip : MonoBehaviour
{
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
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
              
        
        if (Vector3.Distance(initialPosition, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Colisiono1");
        }

    }
}
