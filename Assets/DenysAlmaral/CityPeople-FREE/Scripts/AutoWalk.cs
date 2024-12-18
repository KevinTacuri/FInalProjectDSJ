using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints
    public float speed = 2f; // Velocidad del NPC
    private int currentWaypointIndex = 0; // Índice del waypoint actual
    private int direction = 1; // 1 para avanzar, -1 para retroceder

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Mover hacia el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 directionToWaypoint = (targetWaypoint.position - transform.position).normalized;
        transform.position += directionToWaypoint * speed * Time.deltaTime;

        // Si está cerca del waypoint actual, cambiar al siguiente
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Cambiar el índice dependiendo de la dirección
            currentWaypointIndex += direction;

            // Revertir dirección al alcanzar el extremo
            if (currentWaypointIndex >= waypoints.Length || currentWaypointIndex < 0)
            {
                direction *= -1;
                currentWaypointIndex += direction;
            }
        }

        // Opcional: rotar el NPC hacia la dirección del movimiento
        if (directionToWaypoint != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToWaypoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}