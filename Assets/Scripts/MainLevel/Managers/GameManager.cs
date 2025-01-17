using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] SpecialSkill specialSkill;
    [SerializeField] Timer timer;
    [SerializeField] Score score;
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] AudioManager audioManager;
    [SerializeField] float gameOverSFX_delayTime;
    [SerializeField] float restartDelayTime;
    [SerializeField] float goToMainMenuDelayTime;
    [Header("Buttons")]
    [SerializeField] Button resumeButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button menuButton;
    [SerializeField] VerticalLayoutGroup buttonGroup2;
    PlayerController playerController;
    CapsuleCollider playerCapsuleCollider;
    const int defaultLayer = 0;

    public void Init(PlayerController playerController)
    {
        this.playerController = playerController;
        playerCapsuleCollider = playerController.GetComponentInChildren<CapsuleCollider>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        audioManager.PlayCountdownSFX();

        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            Time.timeScale = 1f;
            timer.enabled = true;
            specialSkill.enabled = true;
            levelGenerator.enabled = true;
            score.enabled = true;
            pauseButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            audioManager.PlayBackgroundMusics();

        }, audioManager.CountdownSFX_length - 0.5f));
    }

    void EndGame()
    {
        Time.timeScale = 0.25f;
        timer.enabled = false;
        Destroy(obstacleSpawner);
        playerController.SetGameOver();
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        StartCoroutine(Utility.DoCoroutine(delegate()
        {
            buttonGroup2.gameObject.SetActive(true);
            audioManager.PlayGameOverSFX();

        }, gameOverSFX_delayTime));
    }

    public void EndGameByDeath()
    {
        StartCoroutine(Utility.DoCoroutine(() => playerCapsuleCollider.enabled = false, 2f));
        levelGenerator.enabled = false;

        EndGame();
    }

    public void EndGameByTime()
    {
        score.SetGameOver();
        Destroy(playerController.GetComponent<PlayerCollisionHandler>());
        playerCapsuleCollider.gameObject.layer = defaultLayer;
        Destroy(playerController.GetComponentInChildren<SphereCollider>());

        EndGame();
    }

    public void RestartGame()
    {
        audioManager.PlaySpecialButtonSFX();

        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);

        }, restartDelayTime));
    }

    public void GoToMainMenu()
    {
        audioManager.PlaySpecialButtonSFX();

        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);

        }, goToMainMenuDelayTime));
    }

    public void OpenMenu()
    {
        PauseGame();
        buttonGroup2.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        audioManager.PlayButtonSFX();
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        audioManager.PlayButtonSFX();
        Time.timeScale = 1f;
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        buttonGroup2.gameObject.SetActive(false);
    }
}
