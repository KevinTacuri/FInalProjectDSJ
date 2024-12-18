using UnityEngine;
using TMPro;

public class TrafficLightController : MonoBehaviour
{
    public Renderer redLight;
    public Renderer greenLight;
    public Renderer yellowLight;

    public Material redMaterial;
    public Material greenMaterial;
    public Material yellowMaterial;
    public Material offMaterial;

    public TextMeshPro timerText;

    public Color redColor = Color.red;
    public Color greenColor = Color.green;
    public Color yellowColor = Color.yellow;

    private float redTime = 12f;
    private float greenTime = 12f;
    private float yellowTime = 3f;

    private float timer;

    public enum TrafficLightState { Red, Yellow, Green }
    public TrafficLightState currentState;

    private GameManager gameManager;

    void Start()
    {
        SetRedLight();
        timer = redTime;
        currentState = TrafficLightState.Red;
        UpdateTimerText();

        gameManager = FindObjectOfType<GameManager>();

        Debug.Log("TrafficLightController initialized.");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimerText();

        if (timer <= 0f)
        {
            if (currentState == TrafficLightState.Red)
            {
                SetGreenLight();
                timer = greenTime;
                currentState = TrafficLightState.Green;
            }
            else if (currentState == TrafficLightState.Green)
            {
                SetYellowLight();
                timer = yellowTime;
                currentState = TrafficLightState.Yellow;
            }
            else if (currentState == TrafficLightState.Yellow)
            {
                SetRedLight();
                timer = redTime;
                currentState = TrafficLightState.Red;
            }
        }
    }

    void SetRedLight()
    {
        redLight.material = redMaterial;
        greenLight.material = offMaterial;
        yellowLight.material = offMaterial;
        timerText.color = redColor;
    }

    void SetGreenLight()
    {
        redLight.material = offMaterial;
        greenLight.material = greenMaterial;
        yellowLight.material = offMaterial;
        timerText.color = greenColor;
    }

    void SetYellowLight()
    {
        redLight.material = offMaterial;
        greenLight.material = offMaterial;
        yellowLight.material = yellowMaterial;
        timerText.color = yellowColor;
    }

    void UpdateTimerText()
    {
        timerText.text = Mathf.Ceil(timer).ToString();
    }
}




