using UnityEngine;
using TMPro;

public class FinishLineTrigger : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI resultText;  // Referencia al componente de texto TMP para mostrar el mensaje final

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.transform.root.CompareTag("Car"))
        {
            Debug.Log("Finish line crossed");

            if (gameManager != null)
            {
                // Verifica la puntuación y muestra el mensaje adecuado
                if (gameManager.points > 12)
                {
                    resultText.text = "Felicidades, aprobaste";
                }
                else
                {
                    resultText.text = "Fallaste, sigue intentando";
                }
            }
        }
    }
}
