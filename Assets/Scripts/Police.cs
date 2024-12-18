using UnityEngine;

public class Police : MonoBehaviour
{
    public Transform thief; // Referencia al ladrón
    public float speed = 6f; // Velocidad del policía
    public float stoppingDistance = 1f; // Distancia mínima para detenerse

    void Update()
    {
        SeekThief();
    }

    void SeekThief()
    {
        // Calcular dirección hacia el ladrón
        Vector3 direction = (thief.position - transform.position).normalized;

        // Mover al policía hacia el ladrón
        if (Vector3.Distance(transform.position, thief.position) > stoppingDistance)
        {
            transform.position += direction * speed * Time.deltaTime;

            // Rotar hacia el ladrón
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }
    }
}
