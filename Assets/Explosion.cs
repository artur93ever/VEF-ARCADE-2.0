using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 10f;

    private void Start()
    {
        // Schedule the destruction of the GameObject after 10 seconds
        Invoke("DestroyGameObject", 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        foreach (Transform child in explosion.transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.AddExplosionForce(explosionForce, explosion.transform.position, 1.0f);
        }
        DestroyGameObject();
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
