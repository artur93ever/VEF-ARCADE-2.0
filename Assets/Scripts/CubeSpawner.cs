using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject targetObject;
    public float minSpawnInterval = 3.0f; // Minimum spawn interval
    public float maxSpawnInterval = 6.0f; // Maximum spawn interval
    public float launchForce = 10.0f;
    public Color changeColor = Color.red;

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            float spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval); // Generate random spawn interval
            yield return new WaitForSeconds(spawnInterval);

            Renderer renderer = targetObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material.color = changeColor;

                yield return new WaitForSeconds(0.3f);

                renderer.material.color = Color.white;
            }

            GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 launchDirection = (Camera.main.transform.position - transform.position).normalized;
                rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            }
        }
    }
}
