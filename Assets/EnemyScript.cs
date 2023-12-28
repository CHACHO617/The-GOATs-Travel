using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab

    public GameObject explosion;
    public Transform cannonTransform;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet1", Random.Range(3f, 7f), Random.Range(3f, 7f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireBullet1()
    {
        // Instantiate a bullet at the enemy's position and rotation
        Instantiate(bulletPrefab, cannonTransform.position, cannonTransform.rotation);
        Debug.Log("shoot");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GoodBullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

}
