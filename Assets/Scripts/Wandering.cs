using UnityEngine;
using System.Collections;

public class Wandering : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento
    public float changeTargetTime = 3f; // Tiempo para cambiar de dirección
    public Vector2 areaCenter; // Centro del área delimitada
    public Vector2 areaSize; // Tamaño del área (ancho y alto)

    private Vector3 targetPosition;

    void Start()
    {
        // Inicializa la posición objetivo
        SetRandomTargetPosition();
        StartCoroutine(ChangeTargetPeriodically());
    }

    void Update()
    {
        // Mover al objetivo
        MoveToTarget();
    }

    void SetRandomTargetPosition()
    {
        float x = Random.Range(areaCenter.x - areaSize.x / 2, areaCenter.x + areaSize.x / 2);
        float z = Random.Range(areaCenter.y - areaSize.y / 2, areaCenter.y + areaSize.y / 2);
        targetPosition = new Vector3(x, transform.position.y, z);
    }


    void MoveToTarget()
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Gira el personaje para mirar hacia el objetivo
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Mueve el personaje hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Verifica si llegó al objetivo con un margen de tolerancia
        if (Vector3.Distance(transform.position, targetPosition) <= 0.5f)
        {
            SetRandomTargetPosition();
        }
    }



    IEnumerator ChangeTargetPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeTargetTime);
            SetRandomTargetPosition();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el área delimitada en la escena (solo visible en el editor)
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(areaCenter.x, transform.position.y, areaCenter.y), new Vector3(areaSize.x, 1, areaSize.y));
    }
}
