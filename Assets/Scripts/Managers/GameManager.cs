using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Timer timer;
    [SerializeField] PlayerController playerController;
    [SerializeField] CapsuleCollider playerCapsuleCollider;
    [SerializeField] Button restartButton;
    [SerializeField] float gameOverSFX_delayTime;
    [SerializeField] float restartDelayTime;

    void Update()
    {
        if (timer.TimeLeft <= 0)
        {            
            EndGameByTime();
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0.25f;
        timer.enabled = false;
        Destroy(obstacleSpawner);
        playerController.enabled = false;        
        enabled = false;
        StartCoroutine(Utility.DoCoroutine(delegate()
        {
            restartButton.gameObject.SetActive(true);
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
        Destroy(playerController.GetComponent<Rigidbody>());
        EndGame();
    }

    public void RestartGame()
    {
        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }, restartDelayTime));
    }
}
