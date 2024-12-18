using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float speed = 10f; // Velocidad del coche
    public float moveDistance = 100f; // Distancia que debe recorrer antes de destruirse

    private float distanceTraveled = 0f;
    private bool isStopped = false;
    private TrafficLightController trafficLight;

    void Start()
    {
        // Encuentra el semáforo en la escena y obtén su componente TrafficLightController
        GameObject trafficLightObject = GameObject.FindGameObjectWithTag("TrafficLight");
        if (trafficLightObject != null)
        {
            trafficLight = trafficLightObject.GetComponent<TrafficLightController>();
        }
    }

    void Update()
    {
        // Mueve el coche solo si no está detenido
        if (!isStopped)
        {
            MoveCar();
        }
    }

    private void MoveCar()
    {
        float move = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
        distanceTraveled += move;

        if (distanceTraveled >= moveDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrafficLight") && trafficLight != null)
        {
            // Detener el coche si el semáforo está en rojo
            if (trafficLight.currentState == TrafficLightController.TrafficLightState.Red)
            {
                isStopped = true;
                Debug.Log("Car stopped at red light.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrafficLight") && trafficLight != null)
        {
            // Reanudar el movimiento si el semáforo está en verde o amarillo
            if (trafficLight.currentState == TrafficLightController.TrafficLightState.Green ||
                trafficLight.currentState == TrafficLightController.TrafficLightState.Yellow)
            {
                isStopped = false;
                Debug.Log("Car resumed movement at green or yellow light.");
            }
        }
    }
}

