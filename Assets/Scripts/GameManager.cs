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
        if (timer.timeLeft <= 0)
        {
            EndSession();
        }
    }

    void EndSession()
    {
        timer.enabled = false;
        distanceScore.enabled = false;
        obstacleSpawner.gameObject.SetActive(false);
        playerController.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        enabled = false;
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameCoroutine());
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }
}
