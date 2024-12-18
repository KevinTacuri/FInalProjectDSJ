using UnityEngine;

public class OffTrackTrigger : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Encuentra el GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called on OffTrackTrigger with: " + other.tag);  // Debug message
        if (other.CompareTag("Car") || other.transform.root.CompareTag("Car"))
        {
            Debug.Log("El coche se salió de la pista");
            if (gameManager != null)
            {
                gameManager.SubtractPoints(1);  // Resta 1 punto
            }
        }
    }
}
