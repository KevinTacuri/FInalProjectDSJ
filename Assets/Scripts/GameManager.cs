using UnityEngine;
using TMPro;  // Asegúrate de añadir esta línea

public class GameManager : MonoBehaviour
{
    public int points = 20;  // Puntos iniciales
    public TextMeshProUGUI pointsText;  // Referencia al componente de texto TMP para mostrar los puntos

    void Start()
    {
        UpdatePointsText();
    }

    public void SubtractPoints(int amount)
    {
        Debug.Log("SubtractPoints called with amount: " + amount);  // Debug message
        points -= amount;
        if (points < 0) points = 0;
        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            Debug.Log("Updating points text to: " + points);  // Debug message
            pointsText.text = "Puntos: " + points.ToString();
        }
    }
}
