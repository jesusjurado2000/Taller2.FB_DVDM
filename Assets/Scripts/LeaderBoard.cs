using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI txtMedalla;
    public Image medalImage;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    private int highScore;
    [SerializeField] private GameObject pausa;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        leaderboardPanel.SetActive(false);
    }

    public void ShowLeaderboard(int finalScore)
    {
        leaderboardPanel.SetActive(true);
        pausa.SetActive(false);
        currentScoreText.text = finalScore.ToString();

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = highScore.ToString();

        if (finalScore >= 30)
        {
            medalImage.sprite = goldMedal;
            txtMedalla.text = "Oro";
        }
        else if (finalScore >= 20)
        {
            medalImage.sprite = silverMedal;
            txtMedalla.text = "Plata";
        }
        else if (finalScore >= 10)
        {
            medalImage.sprite = bronzeMedal;
            txtMedalla.text = "Bronce";
        }
        else
        {
            medalImage.enabled = false;
            txtMedalla.text = "";
        }
    }
}
