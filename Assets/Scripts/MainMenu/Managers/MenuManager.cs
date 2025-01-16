using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MenuAudioManager menuAudioManager;
    [SerializeField] UserChoiceSetter userChoiceSetter;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] float switchCanvasDelayTime;    
    GameObject current;
    [SerializeField] float startDelayTime;

    void Start()
    {
        current = mainCanvas;
    }

    public void SwitchCanvas(GameObject target)
    {
        menuAudioManager.PlayButtonSFX();
        StartCoroutine(SwitchCanvasCoroutine(target));
    }

    public void ExitGame()
    {
        menuAudioManager.PlaySpecialButtonSFX();
        Application.Quit();
    }

    IEnumerator SwitchCanvasCoroutine(GameObject target)
    {
        current.SetActive(false);

        yield return new WaitForSecondsRealtime(switchCanvasDelayTime);

        target.SetActive(true);
        current = target;
    }    

    public void StartGame()
    {
        menuAudioManager.PlaySpecialButtonSFX();

        userChoiceSetter.SetChoice();

        current.SetActive(false);

        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            SceneManager.LoadScene(1);
        }, startDelayTime));
    }
}
