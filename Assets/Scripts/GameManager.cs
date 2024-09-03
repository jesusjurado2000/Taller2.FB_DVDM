using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToReloadScene;
    [Space, SerializeField] private UnityEvent onStartGame;
    [SerializeField] private UnityEvent onGameOver, onIncreaseScore;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private Leaderboard leaderboard;

    public int score
    {
        get;
        private set;
    }

    public bool isGameOver
    {
        get;
        private set;
    }
    
    public bool InicioJuego
    {
        get;
        private set;
    }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(this.gameObject);
    }

    public void StartGame()
    {
        Debug.Log("GameManager :: StartGame()");
        InicioJuego = true;
        PauseButton.SetActive(true);
        onStartGame?.Invoke();
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        Debug.Log("GameManager :: GameOver()");

        isGameOver = true;

        leaderboard.ShowLeaderboard(score);

        onGameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        Debug.Log("GameManager :: IncreaseScore()");

        score++;

        onIncreaseScore?.Invoke();
    }

    public void MenuButton()
    {
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(timeToReloadScene);

        Debug.Log("GameManager :: ReloadScene()");

        SceneManager.LoadScene("Main");
    }
}
