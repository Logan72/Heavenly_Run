using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Distance distanceScore;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] PlayerController playerController;
    [SerializeField] Button restartButton;

    void Update()
    {
        if (timer.TimeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0.25f;
        timer.enabled = false;
        distanceScore.enabled = false;
        obstacleSpawner.gameObject.SetActive(false);
        playerController.enabled = false;
        restartButton.gameObject.SetActive(true);
        enabled = false;
    }

    public void RestartGame()
    {        
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
