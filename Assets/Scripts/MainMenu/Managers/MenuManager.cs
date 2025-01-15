using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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
        StartCoroutine(SwitchCanvasCoroutine(target));
    }

    public void ExitGame()
    {
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
        userChoiceSetter.SetChoice();

        current.SetActive(false);

        StartCoroutine(Utility.DoCoroutine(delegate ()
        {
            SceneManager.LoadScene(1);
        }, startDelayTime));
    }
}
