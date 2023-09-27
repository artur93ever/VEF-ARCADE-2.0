using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject parentObject;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explodable"))
        {
            foreach (Transform child in parentObject.transform)
            {
                child.gameObject.SetActive(true);
            }

            MeshRenderer renderer = parentObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // Disable the MeshRenderer
            }

            StartCoroutine(DestroyCube());
        }
    }

    IEnumerator DestroyCube()
    {
        yield return new WaitForSeconds(3);
        Destroy(parentObject);
    }
}
