using UnityEngine;

public class Thief : MonoBehaviour
{
    public Transform[] waypoints; // Lista de waypoints para las esquinas y bordes de la cuadra
    public float speed = 5f; // Velocidad del ladrón
    public float waypointTolerance = 0.5f; // Distancia mínima para considerar que llegó a un waypoint
    private int currentWaypointIndex = 0; // Índice del waypoint actual

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (waypoints.Length == 0) return; // Si no hay waypoints, no hacer nada

        // Obtener la posición del waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Moverse hacia el waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Rotar hacia el waypoint
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }

        // Cambiar al siguiente waypoint si está cerca del actual
        if (Vector3.Distance(transform.position, targetWaypoint.position) < waypointTolerance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
