using UnityEngine;

public class TrafficLightTrigger : MonoBehaviour
{
    private GameManager gameManager;
    public TrafficLightController trafficLightController;  // Referencia al controlador del semáforo

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (trafficLightController == null)
        {
            Debug.LogError("TrafficLightController no asignado en TrafficLightTrigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter llamado en TrafficLightTrigger con: " + other.tag);

        if (other.CompareTag("Car") || other.transform.root.CompareTag("Car"))
        {
            Debug.Log("Estado del semáforo: " + trafficLightController.currentState);

            if (trafficLightController != null && trafficLightController.currentState == TrafficLightController.TrafficLightState.Red)
            {
                Debug.Log("El coche pasó la luz roja");
                if (gameManager != null)
                {
                    gameManager.SubtractPoints(3);
                }
            }
        }
    }
}

