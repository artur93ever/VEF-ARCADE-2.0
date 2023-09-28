using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Assign your cube prefab in the Inspector
    public float spawnInterval = 1.0f; // Adjust this to control the spawn rate
    public float launchForce = 10.0f; // Adjust this to control the launch force

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Invert the direction to make it move away from the player
                Vector3 launchDirection = (Camera.main.transform.position - transform.position).normalized;

                // Apply the force with the inverted direction
                rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
