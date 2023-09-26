using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BallDestroySpawn : MonoBehaviour
{
    public GameObject ballPrefab; // Reference to the prefab
    public GameObject spawnerBall;
    private bool hasSpawnedBall = false; // To keep track if a cube has been spawned

    private void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!hasSpawnedBall && collision.gameObject.tag == "TorusWall")
        {
            hasSpawnedBall = true; // Set to true so that another cube won't be spawned in this collision event

            GameObject newBall = Instantiate(ballPrefab, spawnerBall.transform.position, Quaternion.identity);

            // Set a delay before destroying the cube
            StartCoroutine(DestroyCubeWithDelay(2f));
        }
    }

    private IEnumerator DestroyCubeWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
