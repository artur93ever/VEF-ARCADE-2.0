using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI conesUsedText;
    public Image starImage1;
    public Image starImage2;
    public Image starImage3;

    public Image otherStarImage1;
    public Image otherStarImage2;
    public Image otherStarImage3;

    [Header("Score Canvas Settings")]
    public GameObject scoreCanvas;
    [Range(1f, 10f)] // Set a reasonable range for spawnDistance
    public float spawnDistance;
    public float verticalOffset; // New variable for vertical position
    public float horizontalOffset; // New variable for horizontal position


    public bool countingAllowed = true;

    [System.Serializable]
    public class ConeStarRating
    {
        public int minCones;
        public int maxCones;
        public int stars;
    }

    public ConeStarRating[] coneStarRatings;

    public int conesUsed;
    public int stars; // Changed to private

    public int Stars // Property to retrieve the value of stars
    {
        get { return stars; }
    }

    // Function to update the score based on the number of cones used
    public void UpdateScore(int cones)
    {
        if (!countingAllowed) return; // If counting is not allowed, return without updating the score

        conesUsed = cones;

        foreach (var rating in coneStarRatings)
        {
            if (conesUsed >= rating.minCones && conesUsed <= rating.maxCones)
            {
                stars = rating.stars;
                break;
            }
        }

        ShowScoreCanvas();
        conesUsedText.text = "" + conesUsed.ToString();
        ToggleStarImages();
    }

    void Update()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            UnityEngine.Debug.LogError("Main camera not found.");
            return;
        }

        // Calculate the new position of the scoreCanvas
        Vector3 newPosition = mainCamera.transform.position +
            mainCamera.transform.forward.normalized * spawnDistance +
            mainCamera.transform.up.normalized * verticalOffset +
            mainCamera.transform.right.normalized * horizontalOffset;

        // Set the new position of the scoreCanvas
        scoreCanvas.transform.position = newPosition;

        // Make the scoreCanvas always face the camera
        scoreCanvas.transform.forward = mainCamera.transform.forward;
    }

    // Function to display the score canvas
    private void ShowScoreCanvas()
    {
        // Add your logic to show the canvas with stars here
    }

    private void ToggleStarImages()
    {
        starImage1.enabled = stars >= 1;
        starImage2.enabled = stars >= 2;
        starImage3.enabled = stars >= 3;

        // Toggle star images on the other canvas
        otherStarImage1.enabled = stars >= 1;
        otherStarImage2.enabled = stars >= 2;
        otherStarImage3.enabled = stars >= 3;
    }
}
