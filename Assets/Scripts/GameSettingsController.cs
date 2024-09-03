using UnityEngine;

public class GameSettingsController : MonoBehaviour
{
    // Singleton para asegurarse de que haya solo una instancia
    public static GameSettingsController Instance;

    [Header("Bird Settings")]
    public Animator birdAnimator; // Referencia al Animator del pájaro
    public RuntimeAnimatorController yellowBirdAnimator;
    public RuntimeAnimatorController redBirdAnimator;
    public RuntimeAnimatorController blueBirdAnimator;

    [Header("Background Settings")]
    public SpriteRenderer backgroundRenderer; // Renderer del fondo
    public Sprite dayBackgroundSprite;
    public Sprite nightBackgroundSprite;

    private string selectedBirdColor;
    public string selectedTimeOfDay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SelectRandomSettings();
        ApplySettings();
    }

    private void SelectRandomSettings()
    {
        string[] birdColors = { "Yellow", "Red", "Blue" };
        selectedBirdColor = birdColors[Random.Range(0, birdColors.Length)];

        string[] timesOfDay = { "Day", "Night" };
        selectedTimeOfDay = timesOfDay[Random.Range(0, timesOfDay.Length)];
    }

    private void ApplySettings()
    {
        switch (selectedBirdColor)
        {
            case "Yellow":
                birdAnimator.runtimeAnimatorController = yellowBirdAnimator;
                break;
            case "Red":
                birdAnimator.runtimeAnimatorController = redBirdAnimator;
                break;
            case "Blue":
                birdAnimator.runtimeAnimatorController = blueBirdAnimator;
                break;
        }

        switch (selectedTimeOfDay)
        {
            case "Day":
                backgroundRenderer.sprite = dayBackgroundSprite;
                break;
            case "Night":
                backgroundRenderer.sprite = nightBackgroundSprite;
                break;
        }
    }
}
