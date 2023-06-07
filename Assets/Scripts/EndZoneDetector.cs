using UnityEngine;

public class EndZoneDetector : MonoBehaviour
{
    public GameObject continueMenuUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the continue menu UI
            continueMenuUI.SetActive(true);
        }
    }
}
