using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroySpawn : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject spawnerCube1;
    public GameObject spawnerCube2;
    public GameObject cubePrefab;
    public GameObject coneMesh;

    [Header("Attractor Settings")]
    public GameObject tutorialAttractor;
    public Attractor attractor;

    [Header("Other Settings")]
    public Animator torusTutorialAnimator;
    public ScoreSystem scoreSystem;
    public float triesToNewSpawn;

    private bool hasSpawnedCube;
    private bool hasCenterSpawned = false;
    private XRGrabInteractable interactable;
    private Collider mycollider;
    private static GameObject existingAttractor;
    private GameObject newAttractor;
    private PlayerCubeEnabledAttractor playerCubeEnabled;

    private static int destroyCount = 0;
    private static int conesCount = 0;

    private BoxCollider boxCollider;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);


        mycollider = GetComponent<Collider>();
        mycollider.enabled = true;
        coneMesh.SetActive(true);

        attractor.enabled = false;

        playerCubeEnabled = GetComponent<PlayerCubeEnabledAttractor>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        CheckHasCenterBool();
        SpawnStartAttractor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasSpawnedCube && collision.gameObject.CompareTag("TorusWall"))
        {
            conesCount++;
            hasSpawnedCube = true;
            GetComponent<Collider>().enabled = false;
            UnityEngine.Debug.Log(" Attractor HIT");
            destroyCount++;
            coneMesh.SetActive(false);

            scoreSystem.UpdateScore(conesCount);

            StartCoroutine(DestroyCubeWithDelay(1f));
        }
    }

    private IEnumerator DestroyCubeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 spawnPosition = hasCenterSpawned ? spawnerCube2.transform.position : spawnerCube1.transform.position;
        Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        attractor.enabled = true;
        boxCollider.enabled = false;
        destroyCount = (int)triesToNewSpawn;
        if (torusTutorialAnimator != null)
        {
            torusTutorialAnimator.Play("TorusTutorial_exitAnim");
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        UnityEngine.Debug.Log("Released");
        boxCollider.enabled = true;
    }

    private void SpawnStartAttractor()
    {
        if (existingAttractor == null && !hasCenterSpawned)
        {
            newAttractor = Instantiate(tutorialAttractor, tutorialAttractor.transform.position, Quaternion.identity);
            existingAttractor = newAttractor;
        }
        else
        {
            newAttractor = existingAttractor;
        }
    }

    private void CheckHasCenterBool()
    {
        hasCenterSpawned = destroyCount >= triesToNewSpawn;

        if (hasCenterSpawned)
        {
            UnityEngine.Debug.Log("hasCenterSpawned is true");
            Destroy(existingAttractor.gameObject);
            playerCubeEnabled.enabled = false;
        }
    }

    public void InitializeVariables()
    {
        hasSpawnedCube = false;
        hasCenterSpawned = false;
        destroyCount = 0;
        conesCount = 0;
        // Set any other variables to their default values here
    }
}
